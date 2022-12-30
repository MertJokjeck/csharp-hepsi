
int[] sayilar= new int[6];
int[]pcSayilar=new int[6];
int tahmin=0;

Console.WriteLine("6 syı girin:");
Random rnd=new Random();

for (int i = 0; i < 6; i++)
{
    Console.WriteLine("{0}. Sayıyı Giriniz ???",(i+1));
    sayilar[i]=int.Parse(Console.ReadLine()!);
    pcSayilar[i]=rnd.Next(1,6);
}
foreach (var sayi in sayilar)
{
    foreach (var pcSayi in pcSayilar)
    {
        tahmin=sayi==pcSayi ? tahmin++: tahmin;
    }
}
Console.WriteLine("{0} adet doğru bidin bravo ", tahmin);

