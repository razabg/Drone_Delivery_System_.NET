using IDAL.DO.DalObject;
using IDAL.DO;
using IDAL;
using System;




namespace IDAL
{
    namespace DO
    {
        namespace DalObject
        {
            class Program
            {

                enum MenuOptions { Exit, Add, Update, ShowEntities, ShowLists }
                enum EntitiesOptions { Exit, Station, Drone, Customer, Parcel }
                enum UpdateOptions { Exit, Assignment, PickedUp, Dalivary, Recharge }
                enum ListOptions { Exit, Stations, Drones, Customers, Parcels, UnAssgnmentParcels, AvailableChagingStations }

                static void Main(string[] args)
                {
                    Console.WriteLine("welcome!\n");
                    Console.WriteLine("Menu Options:\n1 - Add\n2 - Update\n3 - Show emptities\n4 - Show lists\n0 - Exit\n");

                    MenuOptions menuChoceOption = (MenuOptions)int.Parse(Console.ReadLine());
                    do
                    {


                        switch (menuChoceOption)
                        {
                            case MenuOptions.Add:
                                Console.WriteLine("I want to add:\n1 - A station\n2 - A drone\n3 - A customer\n4 - A parcel\n 0 - Exit\n");
                                EntitiesOptions entityChoceOption = (EntitiesOptions)int.Parse(Console.ReadLine());
                                DalObject addFunc = new DalObject();
                                switch (entityChoceOption)
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
                                Console.WriteLine("Which entity from the follow list do you want to update:\n");
                                Console.WriteLine("1 - An assignment\n2 - A pickedup\n3 - A dalivary\n4 - A recharge\n0 - Exit\n");
                                UpdateOptions updateChoceOption = (UpdateOptions)int.Parse(Console.ReadLine());
                                switch (updateChoceOption)
                                {
                                    case UpdateOptions.Assignment:
                                        break;
                                    case UpdateOptions.PickedUp:
                                        break;
                                    case UpdateOptions.Dalivary:
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
                                EntitiesOptions entityChoice = (EntitiesOptions)int.Parse(Console.ReadLine());
                                Console.WriteLine("Please enter the entetity's Id:\n");
                                int key = int.Parse(Console.ReadLine());

                                switch (entityChoice)
                                {
                                    case EntitiesOptions.Exit:
                                        break;
                                    case EntitiesOptions.Station:
                                        DalObject.findAndPrint_Station(key);
                                        break;
                                    case EntitiesOptions.Drone:
                                        DalObject.findAndPrint_Drone(key);
                                        break;
                                    case EntitiesOptions.Customer:
                                        DalObject.findAndPrint_Customer(key);
                                        break;
                                    case EntitiesOptions.Parcel:
                                        DalObject.findAndPrint_Parcel(key);
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case MenuOptions.ShowLists:
                                Console.WriteLine("Which list from the follow lists are you looking for:\n");
                                Console.WriteLine("1 - Stations\n2 - Drones\n3 - Customers\n4 - Parcels\n5 - UnAssignmentParcels\n6 - AvailableChargingStations\n0 - Exit\n");
                                ListOptions listChoceOption = (ListOptions)int.Parse(Console.ReadLine());
                                switch (listChoceOption)
                                {
                                    case ListOptions.Exit:
                                        break;
                                    case ListOptions.Stations:
                                        break;
                                    case ListOptions.Drones:
                                        break;
                                    case ListOptions.Customers:
                                        break;
                                    case ListOptions.Parcels:
                                        break;
                                    case ListOptions.UnAssgnmentParcels:
                                        break;
                                    case ListOptions.AvailableChagingStations:
                                        break;
                                    default:
                                        break;

                                }
                                break;

                            case MenuOptions.Exit:

                                break;

                            default:

                                break;

                        };
                    } while ();
                }

            }
        }
    }
}
