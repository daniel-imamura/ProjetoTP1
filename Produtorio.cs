class Produtorio
{
    protected double
        produto;

    protected int
        quantNum;

    bool
        erroMedia;

    public Produtorio()
    {
        produto = 1;
        quantNum = 0;
    }

    public void Multiplicar(double valorAMultiplicar)
    {
        produto *= valorAMultiplicar;
        quantNum++;
    }

    public double MediaGeometrica()
    {
        erroMedia = false;
        if (quantNum > 0)
            return produto / quantNum;

        erroMedia = true;
        return default(double);
    }
    public double Valor
    {
        get { return produto; }
    }
}

