using System;
namespace Cols
{
    public class EnventClass
    {
        public class CarInfoEventArgs : EventArgs
        {
            public CarInfoEventArgs(string car)
            {
                this.Car = car;
            }
            public string Car { get; set; }
        }

        public class CarDealer
        {
            public event EventHandler<CarInfoEventArgs> NewCarInfo;

            public void NewCar(string car)
            {
                Console.WriteLine("CarDealer,new car {0}", car);

                RaiseNewCarInfo(car);
            }

            public virtual void RaiseNewCarInfo(string car)
            {
                EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
                if (newCarInfo != null)
                {
                    newCarInfo(this, new CarInfoEventArgs(car));
                }
            }
        }

        public class Consumer
        {
            private string name;

            public Consumer(string name)
            {
                this.name = name;
            }

            public void NewCarIsHere(object sender, CarInfoEventArgs e)
            {
                Console.WriteLine("{0}: car {1} is new", name, e.Car);
            }
        }

        public static void main(){
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.NewCar("Ferrari");

            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;
            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;
            dealer.NewCar("Red Bull Racing");

            return;
        }
    }
}
