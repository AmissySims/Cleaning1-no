using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning1.Components.PartialClasses
{
    public partial class Order
    {

        public ObservableCollection<OrderService> OrderServices
        {
            get
            {
                return new ObservableCollection<OrderService>(OrderServices);
            }
        }
        public int? QuanityThings
        {
            get
            {
                return this.OrderServices.Sum(x => x.QuanityThings);
            }
        }
        public decimal? TotalCost
        {
            get
            {
                return this.OrderServices.Sum(x => x.QuanityThings * x.Services.Cost);
            }
        }
        //public decimal? TotalSum
        //{
        //    get
        //    {
        //        return this.OrderServices.Sum(x => x.QuanityThings * x.Services.Cost);
        //    }
        //}

    }
}
