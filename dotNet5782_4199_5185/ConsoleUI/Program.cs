using DO.DO;
using DO;
using System;


namespace DAL
{
    class Program
    {
     
    enum MenuOptions { Exit, Add, Update, ShowEntities, ShowLists } // First options list for the user
        enum EntitiesOptions { Exit, Station, Drone, Customer, Parcel } // In case that the user' choice was "ShowEntities" 
        enum UpdateOptions { Exit, Paring, PickedUp, Arrived, Recharge } // In case that the user' choice was "Update"
        enum ListOptions { Exit, Stations, Drones, Customers, Parcels, UnAssignmentParcels, AvailableChagingStations } // In case that the user' choice was "ShowLists"

        static void Main(string[] args)
        {
            bool Flag = true;
            Console.WriteLine("welcome!\n");
            Console.WriteLine("Menu Options:\n1 - Add\n2 - Update\n3 - Show entities\n4 - Show lists\n0 - Exit\n");

            MenuOptions menuChoiceOption = (MenuOptions)int.Parse(Console.ReadLine()); // Creatint a variable of enum- "MenuOptions" for the user choice 
            do
            {


                switch (menuChoiceOption)
                {
                    case MenuOptions.Add:
                        Console.WriteLine("I want to add:\n1 - A station\n2 - A drone\n3 - A customer\n4 - A parcel\n 0 - Exit\n");
                        EntitiesOptions entityChoiceOption = (EntitiesOptions)int.Parse(Console.ReadLine()); // Creatint a variable of enum- "EntitiesOptions" for the user choice
                            IDal addFunc = new DALobject();
                        switch (entityChoiceOption)
                        {
                            case EntitiesOptions.Station:
                                addFunc.AddStation();
                                break;
                            case EntitiesOptions.Drone:
                                addFunc.AddDrone();
                                break;
                            case EntitiesOptions.Customer:
                                addFunc.AddCustomer();
                                break;
                            case EntitiesOptions.Parcel:
                                addFunc.AddParcel();
                                break;
                            case EntitiesOptions.Exit:
                                break;
                            default:
                                break;
                        }
                        break;

                    case MenuOptions.Update:
                        int drone_id = 0;
                        int parcel_id = 0;
                        Console.WriteLine("Which entity from the follow list do you want to update:\n");
                        Console.WriteLine("1 - An assignment\n2 - A pickedup\n3 - A dalivary\n4 - A recharge\n0 - Exit\n");
                        UpdateOptions updateChoceOption = (UpdateOptions)int.Parse(Console.ReadLine()); // Creatint a variable of enum- "UpdateOptions" for the user choice
                         IDal UpdateFunc = new DALobject();
                        switch (updateChoceOption)
                        {
                            case UpdateOptions.Paring:
                               
                                Console.WriteLine("insert drone id");
                                drone_id = int.Parse(Console.ReadLine());
                                Console.WriteLine("insert parcel id");
                                parcel_id = int.Parse(Console.ReadLine());
                                UpdateFunc.UpdateParing(parcel_id,drone_id);
                                break;
                            case UpdateOptions.PickedUp:
                                Console.WriteLine("insert parcel id");
                                parcel_id = int.Parse(Console.ReadLine());
                                UpdateFunc.UpdatePickedUp(parcel_id);
                                break;
                            case UpdateOptions.Arrived:
                                Console.WriteLine("insert parcel id");
                                parcel_id = int.Parse(Console.ReadLine());
                                UpdateFunc.UpdateArrived(parcel_id);
                                break;
                            case UpdateOptions.Recharge:
                                break;
                            case UpdateOptions.Exit:
                                break;
                            default:
                                break;
                        }
                        break;

                    case MenuOptions.ShowEntities:
                        Console.WriteLine("Which entity would you like to see?:\n1 - Station\n2 - Drone\n3 - Customer\n4 - Parcel\n0- Exit\n");
                        EntitiesOptions entityChoice = (EntitiesOptions)int.Parse(Console.ReadLine()); // Creatint a variable of enum- "EntitiesOptions" for the user choice
                        Console.WriteLine("Please enter the entetity's Id:\n");
                        int key = int.Parse(Console.ReadLine());
                        IDal ShowEntites = new DALobject();

                        switch (entityChoice)
                        {
                           
                            case EntitiesOptions.Station:
                                ShowEntites.findAndPrint_Station(key);
                                break;
                            case EntitiesOptions.Drone:
                                ShowEntites.findAndPrint_Drone(key);
                                break;
                            case EntitiesOptions.Customer:
                                ShowEntites.findAndPrint_Customer(key);
                                break;
                            case EntitiesOptions.Parcel:
                                ShowEntites.findAndPrint_Parcel(key);
                                break;
                            case EntitiesOptions.Exit:
                                break;
                            default:
                                break;
                        }
                        break;

                    case MenuOptions.ShowLists:
                        Console.WriteLine("Which list from the follow lists are you looking for:\n");
                        Console.WriteLine("1 - Stations\n2 - Drones\n3 - Customers\n4 - Parcels\n5 - UnAssignmentParcels\n6 - AvailableChargingStations\n0 - Exit\n");
                        ListOptions listChoceOption = (ListOptions)int.Parse(Console.ReadLine()); // Creatint a variable of enum- "ListOptions" for the user choice
                        IDal ShowLists = new DALobject();
                        switch (listChoceOption)
                        {
                            case ListOptions.Exit:
                                break;
                            case ListOptions.Stations:
                                ShowLists.show_station_list();
                                break;
                            case ListOptions.Drones:
                                ShowLists.show_drone_list();
                                break;
                            case ListOptions.Customers:
                                ShowLists.show_customer_list();
                                break;
                            case ListOptions.Parcels:
                                ShowLists.show_parcel_list();
                                break;
                            case ListOptions.UnAssignmentParcels:
                                ShowLists.show_UnassignmentParcel_list();
                                break;
                            case ListOptions.AvailableChagingStations:
                                ShowLists.show_AvailableChargingStations_list();
                                break;
                            default:
                                break;

                        }
                        break;

                    case MenuOptions.Exit: // while the user ask for finish we change Flag to false and the program will finish - {while(false)} 
                        Flag = false;

                        break;

                    default:

                        break;

                };
            } while (Flag);
        }

    }
}


