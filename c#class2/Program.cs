
using c_class2;
using System.Xml.Schema;

class Program
{

    public static void show()
    {

        VehicleConstruct vh = new VehicleConstruct();

       // VehicleConstruct vh = new VehicleConstruct(90, "xyz", "nyc", 90);

       // VehicleConstruct vh2 = new VehicleConstruct(vh);

      //  vh2.GetVehicleStatus();
    }
    public static void Main()
    {
        // Program.show();

        // GC.Collect();

        //TestException.Test();
        // TestException.CheckPrice();

        // Console.WriteLine("done");

        /*var vr = new VehicleRepository();
        var rg = new ReportGenerator();
        var vs = new VehicleService(vr, rg);
        Guid id=Guid.NewGuid();
        vs.AddVehicle(id, "ford", "xyz", 2019);
        vs.PrintVehicleDetails(id);*/

        // ArraySort.DoSort();

        //ArraySort.MultiDimensional();

        //ArraySort.JaggedArray();

        ArraySort.showTuples();
        
        
    }
}