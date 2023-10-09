class Somatoria
{
    protected double
        soma, somaInversos;

    protected int
        quantidadeValores, quantidadeDeValorInversos;

    bool houveErroMedia;
    public Somatoria()
    {
        soma = 0;
        quantidadeValores = 0;
        somaInversos = 0;
        quantidadeDeValorInversos = 0;
        houveErroMedia = false;
    }

    public void Somar(double valorASomar)
    {
        soma += valorASomar;
        quantidadeValores++;
    }
    public double MediaAritmetica()
    {
        houveErroMedia = false;
        if (quantidadeValores > 0)
            return soma / quantidadeValores;

        houveErroMedia = true;
        return default(double);
    }

    public double Valor
    {
        get { return soma; }
    }
    public int Quantos
    {
        get { return quantidadeValores; }
    }
    public void ZerarSoma()
    {
        soma = 0;
        quantidadeValores = 0;
    }
    public void ZerarSomaInversa() 
    {
        somaInversos = 0;
        quantidadeDeValorInversos = 0;
    }
    public double SomarInverso(double valorASerSomado)
    {
        if (valorASerSomado == 0)
        {
            return default(double);
        }
        somaInversos += 1 / valorASerSomado;
        quantidadeDeValorInversos++;
        return somaInversos;
    }
    public double MediaHarmonica() 
    {
        double mediaHarmonica = 0;
        mediaHarmonica = quantidadeDeValorInversos / somaInversos;
        return mediaHarmonica;
    }
}


