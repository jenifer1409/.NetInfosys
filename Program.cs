

using OOPProject;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics;

class Program
{
    public static void Main()
    {
       // Vehicle car1 = new Vehicle();

       // Console.WriteLine(car1.getStatus());

       /* Truck t1 = new Truck();
        t1.CargoCapacity = 100;
        t1.vehicleId = "xyz123";
        t1.Make = "Toyota";
        t1.Model = "Camry";
        t1.UpdateLocation("NYC");
        t1.updateSpeed(100);
        Console.WriteLine(t1.getStatus());


        VehicleInterface vi = new VehicleInterface();
        vi.Location("NJ");
       
        vi.Speed(80);
        vi.Make();
        vi.Model();*/

        VehicleOverload vo = new VehicleOverload();
        Console.WriteLine(vo.updateVehicle(90));
        vo.updateVehicle("nyc");
        vo.updateVehicle("ford", "v1", "nyc", 100);

    }
}
