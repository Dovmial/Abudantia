using AutoFixture;
using static System.Net.WebRequestMethods;

namespace Abudantia.Models
{
    public class Catalog: List<Product>
    {
        public Catalog()
        {
            Fixture fixture = new();
            IEnumerable<Product> res = fixture.CreateMany<Product>(15);
            Clear();
            AddRange(res);

            this[0].ImageLink = "https://avatars.mds.yandex.net/get-mpic/4977072/img_id4659133673044625928.jpeg/orig";
        }
    }
}
