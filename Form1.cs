using System.Globalization;
using GraphsInterpolation;
using ScottPlot;
using ScottPlot.Plottables;

namespace GraphsInterpolation
{
    enum CalcMethod { Lagrange, Aitken, LagrangeandAitken, NotSet };
    public partial class InterpolationForm : Form
    {
        public const double minArgument = 1e-4;
        public const double maxArgument = 1e4;

        private CalcMethod Method { get; set; } = CalcMethod.NotSet;

        private List<TextBox> knownValuesBoxes = new List<TextBox>();

        //вузли інтерполяції
        List<Point> sharedPoints = new List<Point>();

        private List<TextBox> pointsToFindValuesBoxes = new List<TextBox>();

        private List<double> markerArgs = new List<double>();

        private List<ScottPlot.Plottables.Marker> markers = new List<ScottPlot.Plottables.Marker>();

        private const int MaxPoints = 10;
        private const int MaxFileNameLength = 50;
        private const string resultDirName = "Saved results";
        private const string analysisFileName = "iterationAnalysis.txt";

        private double[] Interval = new double[2] { -10, 10 };

        public InterpolationForm()
        {
            InitializeComponent();
            UpdatePointsAmount();
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}");
            DrawComplexityGraph();


            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            Resize += (object s, EventArgs e) => ResizeLayout();
        }

        private void FormsPlot1_SizeChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double start) && double.TryParse(textBox2.Text, out double end))
            {
                AdjustAxesY((start - end) / 2);
            }
            else
            {
                AdjustAxesX();
            }
        }

        private void AdjustAxesX()
        {
            double yMin = Interval[0];
            double yMax = Interval[1];
            double ySpan = yMax - yMin;

            double xCenter = ySpan / 2;

            double pixelRatio = (double)formsPlot1.Width / formsPlot1.Height;

            double xSpan = ySpan * pixelRatio;

            double xMin = xCenter - xSpan / 2;
            double xMax = xCenter + xSpan / 2;

            formsPlot1.Plot.Axes.SetLimits(xMin, xMax, yMin, yMax);
            formsPlot1.Refresh();
        }

        private void AdjustAxesY(double yMin)
        {
            double xMin = Interval[0];
            double xMax = Interval[1];
            double xSpan = xMax - xMin;

            double pixelRatio = (double)formsPlot1.Height / formsPlot1.Width;

            double ySpan = xSpan * pixelRatio;

            double yMax = yMin + ySpan;

            formsPlot1.Plot.Axes.SetLimits(xMin, xMax, yMin, yMax);
            formsPlot1.Refresh();
        }

        private void ResizeLayout()
        {
            int formWidth = ClientSize.Width;
            int formHeight = ClientSize.Height;
            panel1.Height = formHeight;
            panel1.Width = formWidth - panel2.Width;
            panel2.Location = new System.Drawing.Point(formWidth - panel2.Width, 0);
            panel3.Location = new System.Drawing.Point(0, panel1.Height - panel3.Height);
            panel3.Width = panel1.Width;
            formsPlot1.Location = new System.Drawing.Point(0, 0);
            formsPlot1.Width = panel1.Width;
            formsPlot1.Height = formHeight - panel3.Height;
            AdjustAxesX();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Method = CalcMethod.Lagrange;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Method = CalcMethod.Aitken;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Method = CalcMethod.LagrangeandAitken;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdatePointsAmount();
        }

        private void UpdatePointsAmount()
        {
            int pointCount = knownValuesBoxes.Count;
            int newCount = trackBar1.Value;

            if (newCount > pointCount)
            {
                for (int i = pointCount; i < newCount; i++)
                {
                    TextBox textBox = new TextBox();
                    knownValuesBoxes.Add(textBox);
                    textBox.Name = $"point {i + 1}";
                    textBox.Width = 60;
                    textBox.Margin = new Padding(left: 30, top: 5, right: 0, bottom: 5);
                    textBox.PlaceholderText = $"{(char)('a' + i)}";
                    flowLayoutPanel1.Controls.Add(textBox);
                }
            }
            else if (newCount < pointCount)
            {
                for (int i = pointCount - 1; i >= newCount; i--)
                {
                    flowLayoutPanel1.Controls.Remove(knownValuesBoxes[i]);
                    knownValuesBoxes.RemoveAt(i);
                }
            }
        }

        private bool GetPointsFromInputs(List<Point> points, List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                double[] point = ParsePointsInput(textBox.Text);
                if (point != null)
                {
                    foreach (Point copyPoint in points)
                    {
                        if (copyPoint.x == point[0])
                        {
                            MessageBox.Show("Вузли інтерполяції повторюються. Кожен аргумент повинен бути унікальним");
                            return false;
                        }
                    }
                    if ((point[0] != 0 && Math.Abs(point[0]) < minArgument) || Math.Abs(point[0]) > maxArgument
                        || (point[1] != 0 && Math.Abs(point[1]) < minArgument) || Math.Abs(point[1]) > maxArgument)
                    {
                        MessageBox.Show($"Координати вузлів інтерполяції виходять за допустимі межі для цієї програми: [-{maxArgument}; -{minArgument}]∪[{minArgument}; {maxArgument}]∪0");
                        return false;
                    }
                    points.Add(new Point(point));
                }
                else
                {
                    MessageBox.Show("Введено некоректні дані для вузлів інтерполяції");
                    return false;
                }
            }
            points.Sort();
            return true;
        }

        private double[] ParsePointsInput(string input)
        {
            char[] charset = [',', ';'];
            string[] coordinates = input.Split(charset, StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length == 2 && double.TryParse(coordinates[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double x) && double.TryParse(coordinates[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double y))
                return [x, y];
            else
                return null;
        }

        private bool CheckRungePhenomenon()
        {
            if (sharedPoints.Count > 5)
            {
                int countEquidistant = 0;
                double firstXDistance = sharedPoints[1].x - sharedPoints[0].x;
                for (int i = sharedPoints.Count - 1; i > 2; i--)
                {
                    double currentXDistance = sharedPoints[i].x - sharedPoints[i - 1].x;
                    if (Math.Abs(firstXDistance - currentXDistance) < 1.0)
                    {
                        countEquidistant++;
                    }
                }
                if (countEquidistant > sharedPoints.Count / 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMarkersAmount();
        }

        private void UpdateMarkersAmount()
        {
            if (pointsToFindValuesBoxes.Count >= MaxPoints)
            {
                MessageBox.Show($"Не можливо додати більше {MaxPoints} точок");
                return;
            }

            TextBox textBox = new TextBox();
            textBox.Width = 60;
            textBox.PlaceholderText = $"x{pointsToFindValuesBoxes.Count + 1}";
            flowLayoutPanel3.Controls.Add(textBox);

            pointsToFindValuesBoxes.Add(textBox);

            Button deleteButton = new Button();
            deleteButton.Text = "x";
            deleteButton.Height = textBox.Height;
            deleteButton.Width = 60;
            deleteButton.Click += (s, e) =>
            {
                int index = pointsToFindValuesBoxes.IndexOf(textBox);
                if (index >= 0)
                {
                    if (pointsToFindValuesBoxes.Count == markers.Count)
                    {
                        formsPlot1.Plot.Remove(markers[index]);
                        markers.RemoveAt(index);
                    }
                    pointsToFindValuesBoxes.RemoveAt(index);
                    flowLayoutPanel3.Controls.Remove(textBox);
                    flowLayoutPanel3.Controls.Remove(deleteButton);
                }
            };
            flowLayoutPanel3.Controls.Add(deleteButton);

        }

        private void GetMarkersFromInputs()
        {
            for (int i = 0; i < pointsToFindValuesBoxes.Count; i++)
            {
                if (double.TryParse(pointsToFindValuesBoxes[i].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double x))
                {
                    if ((x != 0 && Math.Abs(x) < minArgument) || Math.Abs(x) > maxArgument)
                    {
                        MessageBox.Show($"Точки не будуть відображатися: значення x повинні бути в межах [-{maxArgument}; -{minArgument}]∪[{minArgument}; {maxArgument}]∪0");
                        return;
                    }
                    if (markerArgs.Contains(x))
                    {
                        MessageBox.Show("Точки не відображатимуться: введено декілька обнакових значень");
                        return;
                    }
                    else
                    {
                        markerArgs.Add(x);
                    }
                }
                else
                {
                    MessageBox.Show($"Точки не відображатимуться через їх некоректні вхідні дані");
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formsPlot1.Reset();
            formsPlot1.Refresh();
            sharedPoints.Clear();
            markerArgs.Clear();
            label5.Text = string.Empty;
            label6.Text = string.Empty;
            if (GetPointsFromInputs(sharedPoints, knownValuesBoxes))
            {
                GetMarkersFromInputs();

                if (Method == CalcMethod.NotSet)
                {
                    MessageBox.Show("Оберіть метод інтерполяції!");
                }
                if (CheckRungePhenomenon())
                {
                    MessageBox.Show("Є ймовірність значної похибки на кінцях інтервалу через високий степінь полінома та рівновіддаленість точок!");
                }

                if (Method == CalcMethod.Lagrange || Method == CalcMethod.LagrangeandAitken)
                {
                    LagrangePolynom polynom = new LagrangePolynom(sharedPoints);
                    var myFunc = new Func<double, double>((x) => polynom.SumOfLagrangePolynom(x));
                    var plot = formsPlot1.Plot.Add.Function(myFunc);
                    plot.LineColor = Colors.Green;
                    plot.LineWidth = 2;
                    plot.LegendText = "поліном Лагранжа";
                    formsPlot1.Plot.HideLegend();
                    GetInterval(myFunc);

                    if (markerArgs.Count != 0)
                    {
                        label6.Text = "Відображені точки: ";
                        foreach (double x in markerArgs)
                        {
                            double y = polynom.SumOfLagrangePolynom(x);
                            var marker = formsPlot1.Plot.Add.Marker(x, y, ScottPlot.MarkerShape.FilledCircle, size: 8);
                            label6.Text += $"({x}, {y:0.####}) ";
                            markers.Add(marker);
                        }
                        label6.Visible = true;
                    }
                    formsPlot1.Refresh();
                    label5.Text = new PolynomView().GetSimplifiedPolynomial(sharedPoints);
                    label5.Visible = true;
                }
                if (Method == CalcMethod.Aitken || Method == CalcMethod.LagrangeandAitken)
                {
                    AitkenScheme aitkenTable = new AitkenScheme(sharedPoints);
                    var myFunc = new Func<double, double>((x) => aitkenTable.ValueAtPoint(x));
                    var plot = formsPlot1.Plot.Add.Function(myFunc);
                    plot.LineColor = Colors.Orange;
                    plot.LineWidth = 2;
                    plot.LinePattern = LinePattern.Dashed;
                    plot.LegendText = "схема Ейткена";
                    formsPlot1.Plot.HideLegend();

                    if (Method == CalcMethod.Aitken)
                    {
                        GetInterval(myFunc);
                        if (markerArgs.Count != 0)
                        {
                            label6.Text = "Відображені точки: ";
                            foreach (double x in markerArgs)
                            {
                                double y = aitkenTable.ValueAtPoint(x);
                                var marker = formsPlot1.Plot.Add.Marker(x, y, ScottPlot.MarkerShape.OpenCircle, size: 10);
                                label6.Text += $"({x}, {y:0.####}) ";
                            }
                        }
                        label6.Visible = true;
                        label5.Text = new PolynomView().GetSimplifiedPolynomial(sharedPoints);
                        label5.Visible = true;
                    }
                    formsPlot1.Refresh();
                }
                formsPlot1.Plot.Title(Method.ToString());
                formsPlot1.Refresh();
            }
            button2.Show();
            button4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            trackBar1.Value = 2;
            knownValuesBoxes.Clear();
            pointsToFindValuesBoxes.Clear();
            markerArgs.Clear();
            markers.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel3.Controls.Add(button3);
            formsPlot1.Reset();
            formsPlot1.Refresh();
            UpdatePointsAmount();
            label5.Visible = false;
            label5.Text = "";
            label6.Visible = false;
            label6.Text = "";
            button2.Hide();
            button4.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Axes.Zoom(1.2, 1.2);
            formsPlot1.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Axes.Zoom(0.8, 0.8);
            formsPlot1.Refresh();
        }

        private void GetInterval(Func<double, double> func)
        {
            if (double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double x1) && double.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double x2))
            {
                if (x1 != 0 && (Math.Abs(x1) < minArgument) || Math.Abs(x1) > maxArgument || (x2 != 0 && Math.Abs(x2) < minArgument) || Math.Abs(x2) > maxArgument)
                {
                    MessageBox.Show($"Інтервал повинен бути в межах [-{maxArgument}; -{minArgument}]∪[{minArgument}; {maxArgument}]∪0");
                    return;
                }
                if (x1 < x2)
                {
                    Interval[0] = x1;
                    Interval[1] = x2;
                }
                else
                {
                    Interval[0] = x2;
                    Interval[1] = x1;
                }
                AdjustAxesY(func(x1));
            }
            else
            {
                MessageBox.Show("Графік буде відображено на проміжку за замовчуванням");
                textBox1.Clear();
                textBox2.Clear();
                Interval[0] = sharedPoints[0].x - 1;
                Interval[1] = sharedPoints[sharedPoints.Count - 1].x + 1;
                AdjustAxesY(func(Interval[0]));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = true;
            textBox3.Visible = true;

        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила введення даних\n" +
                "Вузли інтерполяції: десяткову частину вводити через крапку '.', " +
                "координати x та y розділяти використвовуючи крапку з комою або кому ';' ','\n" +
                "Наприклад '2.5; 4' або '5.06, 10.75'\n" +
                "Точки та інтервал: вводити єдине число з крапкою між цілою та дробовою частиною '.'\n" +
                "Наприклад '5.7' або '-9.1'");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = textBox3.Text;
            if (fileName.Length <= MaxFileNameLength || fileName.Length != 0)
            {
                formsPlot1.Plot.ShowLegend();
                formsPlot1.Plot.Legend.Alignment = Alignment.LowerRight;
                formsPlot1.Plot.Legend.FontSize = 14;
                formsPlot1.Refresh();
                formsPlot1.Plot.SavePng($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}\\{fileName}.png", Width, Height);

                formsPlot1.Plot.HideLegend();
                formsPlot1.Refresh();
            }
            else
            {
                MessageBox.Show($"Ім'я файлу повинно не перевищувати {MaxFileNameLength} символів");
            }
            textBox3.Text = "";
            textBox3.Visible = false;
            button5.Visible = false;
            button4.Visible = true;
        }

        static void DrawComplexityGraph()
        {
            ScottPlot.Plot complexityGraph = new ScottPlot.Plot();

            int[] numberOfPoints = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] LagrangeNumberOfIterations = new double[numberOfPoints.Length];
            double[] AitkenNumberOfIterations = new double[numberOfPoints.Length];

            File.WriteAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}\\{analysisFileName}", "");

            List<Point> points = new List<Point>();
            for (int i = 0; i < numberOfPoints.Length; i++)
            {
                for (int j = points.Count; j < numberOfPoints[i]; j++)
                {
                    points.Add(new Point(j, j));
                }
                LagrangePolynom polynom = new LagrangePolynom(points);
                for (double j = 0; j < points[points.Count - 1].x; j += 0.1)
                {
                    polynom.SumOfLagrangePolynom(j);
                }
                File.AppendAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}\\{analysisFileName}", $"Lagrange polynom, {polynom.points.Count} points, iterations: {polynom.iterations}\n");
                LagrangeNumberOfIterations[i] = polynom.iterations;

                AitkenScheme aitkenTable = new AitkenScheme(points);
                for (double j = 0; j < points[points.Count - 1].x; j += 0.1)
                {
                    aitkenTable.ValueAtPoint(j);
                }
                File.AppendAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}\\{analysisFileName}", $"Aitken scheme, {aitkenTable.points.Count} points, iterations: {aitkenTable.iterations}\n");
                AitkenNumberOfIterations[i] = aitkenTable.iterations;
            }

            var Lagrange = complexityGraph.Add.Scatter(numberOfPoints, LagrangeNumberOfIterations);
            Lagrange.LegendText = nameof(Lagrange);
            Lagrange.LineWidth = 2;
            Lagrange.LineColor = Colors.BlueViolet;
            Lagrange.MarkerColor = Colors.BlueViolet;
            var Aitken = complexityGraph.Add.Scatter(numberOfPoints, AitkenNumberOfIterations);
            Aitken.LegendText = nameof(Aitken);
            Aitken.LinePattern = ScottPlot.LinePattern.Dashed;
            Aitken.LineWidth = 2;
            Aitken.LineColor = Colors.Coral;
            Aitken.MarkerColor = Colors.Coral;

            complexityGraph.SavePng($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\{resultDirName}\\{nameof(complexityGraph)}.png", 800, 600);
        }

        private void InterpolationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
