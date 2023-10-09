class Contador
{
    protected
    double
        cont,
        valorInicial,
        valorFinal,
        passo;

    public Contador(double i, double f, double p)
    {
        cont = i;
        valorInicial = i;
        valorFinal = f;
        passo = p;
    }

    public void Iniciar()
    {
        cont = valorInicial;
    }

    public bool Prosseguir()
    {
        return cont <= valorFinal;
    }

    public void Contar()
    {
        if (Prosseguir())
            cont = cont + passo;
    }

    public double Valor
    {
        get => cont; set => cont = value;
    }
}


