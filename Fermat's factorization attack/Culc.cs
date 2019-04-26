using System;
using System.Numerics;
using System.Diagnostics;

namespace Fermat_s_factorization_attack
{
public class Culculate
{
    public string report;
    public Culculate()
    {
        report = "";
    }
    public void NewFact(string str_N)
    {
        BigInteger N = BigInteger.Parse(str_N);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        BigInteger k = Sqrt(N) + 1;
        BigInteger y = k * k - N;
        BigInteger d = 1;

        while (Sqrt(y) * Sqrt(y) != y && Sqrt(y) < N / 2)
        {
            y = y + 2 * k + d;
            d += 2;
        }
        stopwatch.Stop();
        if (Sqrt(y) >= N / 2)
        {
            report += "Множители не найдены\n";
        }
        if (Sqrt(y) * Sqrt(y) == y)
        {
            BigInteger x = Sqrt(N + y);
            y = Sqrt(y);
            report += "Нетривиальные делители " + N.ToString() + ": " + (x + y).ToString() + " и " + (x - y).ToString() + ", разбег " + (y * 2).ToString() + "\n";
        }

        report += "Время работы алгоритма " + stopwatch.Elapsed.TotalMilliseconds + " мс\n\n";
        stopwatch.Reset();
    }

    public BigInteger Sqrt(BigInteger n)
    {
        if (n == 0) return 0;
        if (n > 0)
        {
            int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
            BigInteger root = BigInteger.One << (bitLength / 2);

            while (!isSqrt(n, root))
            {
                root += n / root;
                root /= 2;
            }

            return root;
        }

        throw new ArithmeticException("NaN");
    }

    private Boolean isSqrt(BigInteger n, BigInteger root)
    {
        BigInteger lowerBound = root * root;
        BigInteger upperBound = (root + 1) * (root + 1);

        return (n >= lowerBound && n < upperBound);
    }
}
}
