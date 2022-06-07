namespace MvcEntityFrameworkWithDependenctInjection.Models
{
    // Dependenct Inversion (Bağımlılıkları tersine çevirme) =>  High level modul veya sınıflar Low level modül veya sınıflara arasında sıkı bağlantı yerine gevşek bağlanı olmalıdır...
    // Bağımlılıklar soyutlanmalıdır...


    // DbConnection sınıfı SqlDbConnection sınıfına bağımlılıdır...
    //public class DbConnection // üst seviye sınıf (high level)
    //{
    //    SqlDbConnection cnn;
    //    public void Baglan()
    //    {
    //        //cnn. metotları kullanılır...
    //    }
    //}

    public class DbConnection // üst seviye sınıf (high level)
    {
        IDbConnection cnn;

        public DbConnection(IDbConnection _cnn)
        {
            cnn = _cnn;
        }
        public void Baglan()
        {
            //cnn. metotları kullanılır...
        }
    }
    public interface IDbConnection
    {

    }
    public class SqlDbConnection : IDbConnection // alt seviye sınıf (low level)
    {
    }

    public class OracleDbConnection : IDbConnection // alt seviye sınıf (low level)
    {
    }

    public class MySqlConnection : IDbConnection
    {

    }

    public class Uygulama
    {
        // Dependecny Inversion => bağımlılı tersine çevirme (Prensib)
        // Dependency Injection (DI) => bağımlılığı enjecte etme.. (Pattern). Dependency Injection Dependency Inversion'ın uygulanmasıdır... Bağımlığı tersine çevirip soyutladığın zaman instancelerin DI ile enject edilmesidir...

        // Dependency => Bağımlılık
        // Injection => Enjecte

        DbConnection db = new DbConnection(new SqlDbConnection());

        DbConnection db1 = new DbConnection(new OracleDbConnection());

        DbConnection db2 = new DbConnection(new MySqlConnection());
    }

    // Örnek 2
    // Eğer A B'yi kullanıyorsa A B'ye bağımlıdır..
    public class A
    {
        //B b = new B();
        B b;
        public A(B _b) // B tipindeki varlık A'ya enjecte edilecek
        {
            b = _b;
        }
    }

    public class B
    {
        public B(string str,string s2,int a1) // b'de constructor geliştirmesi A'yı etkiler..
        {

        }
    }
    // bağımlılığu enjecte ettiğimiz sınıfımız
    public class Appss
	{
        void SayfaDon()
		{
            B b = new B("", "", 1); // b instanci oluştu...
            A aa = new A(b); // b'yi enjecte ettik...
        }
	}
}
