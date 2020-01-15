namespace Graph_lines
{
    public class LineEquation
    {
        private double m_a;
        private double m_b;
        private double m_c;

        public LineEquation() { }

        public LineEquation(double a, double b, double c)
        {
            m_a = a;
            m_b = b;
            m_c = c;
        }

        public double A 
        { get { return m_a; } set { m_a = value; } }
        public double B
        { get { return m_b; } set { m_b = value; } }
        public double C
        { get { return m_c; } set { m_c = value; } }

        public double Y(double x)
        {
            if (m_b == 0) 
                return 0;
            return (-m_a / m_b * x) - (m_c / m_b);
        }

    }
}
