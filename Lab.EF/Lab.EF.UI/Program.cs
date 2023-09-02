using Lab.Demo.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            SuppliersLogic suppliersLogic = new SuppliersLogic();


            int menu = 0;
            int salida = 0;


            do
            {
                try
                {

                    Console.WriteLine("\n\nIngresá el número de lo que quieras hacer:\r\n\n" +
                        "                        Transportistas:\r\n" +
                        "                           1. Ver los transportistas actuales\r\n" +
                        "                           2. Añadir un nuevo transportista\r\n" +
                        "                           3. Eliminar algún transportista\r\n" +
                        "                           4. Modificar algún transportista\r\n\n" +
                        "                        Proveedores:\r\n" +
                        "                           5. Ver los proveedores actuales\r\n" +
                        "                           6. Añadir un nuevo proveedor\r\n" +
                        "                           7. Eliminar algun proveedor\r\n" +
                        "                           8. Modificar algun proveedor\r\n" +
                        "                           9. Salir");

                    menu = Convert.ToInt32(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            await MostrarListaDeTransportistasAsync();
                            Console.WriteLine("\n\nPresione cualquier tecla para continuar.");
                            break;


                        case 2:
                            Console.Clear();
                            Console.Write("Ingrese el nombre del transportista: ");
                            string companyName = Console.ReadLine();
                            Console.Write("Ingrese el número de teléfono: ");
                            string phone = Console.ReadLine();
                            var nuevoShipper = new Shippers
                            {
                                CompanyName = companyName,
                                Phone = phone
                            };
                            await shippersLogic.AddAsync(nuevoShipper);

                            Console.WriteLine("Gracias por añadir un transportista, esta es la lista actualizada:\n");
                            await MostrarListaDeTransportistasAsync();

                            break;


                        case 3:
                            Console.Clear();
                            Console.WriteLine("Esta es la lista de transportistas actual:\n");
                            await MostrarListaDeTransportistasAsync();

                            Console.Write("\nIngrese el ID del transportista que desea eliminar: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            int exists = await suppliersLogic.checkExist(id);
                            if(exists > 0)
                            {
                                Console.Write($"Si está seguro que desea eliminar el transportista de ID {id} oprima 1, de lo contrario cualquier otra tecla.");
                                int eliminar = Convert.ToInt32(Console.ReadLine());
                                if (eliminar == 1)
                                {
                                    await shippersLogic.DeleteAsync(id);
                                    Console.WriteLine("Gracias por eliminar el transportista, esta es la lista actualizada:\n");
                                    await MostrarListaDeTransportistasAsync();
                                }
                                else Console.WriteLine("Gracias por recapacitar.");
                            }
                            else Console.WriteLine("La ID ingresada no existe");


                            break;


                        case 4:
                            Console.Clear();
                            Console.WriteLine("Esta es la lista de transportistas actual:\n");
                            await MostrarListaDeTransportistasAsync();

                            Console.Write("Ingrese el ID del transportista que vas a modificar: ");
                            int updateShipperID = int.Parse(Console.ReadLine());
                            int exist = await shippersLogic.checkExist(updateShipperID);
                            if (exist > 0)
                            {
                                Console.Write("Ingrese el nombre: ");
                                string updateCompanyName = Console.ReadLine();
                                Console.Write("Ingrese el número de teléfono: ");
                                string updatePhone = Console.ReadLine();

                                await shippersLogic.UpdateAsync(new Shippers
                                {
                                    ShipperID = updateShipperID,
                                    CompanyName = updateCompanyName,
                                    Phone = updatePhone
                                });

                                Console.Clear();
                                Console.WriteLine($"Gracias por modificar untransportista, esta es la lista actualizada:\n");
                                await MostrarListaDeTransportistasAsync();
                            }
                            else Console.WriteLine("ID inválido, presione alguna tecla para continuar");
                            break;



                        case 5:
                            Console.Clear();
                            await MostrarListaDeProveedoresAsync();
                            Console.WriteLine("\nPresione cualquier tecla para continuar.");
                            break;


                        case 6:
                            Console.Clear();
                            Console.WriteLine("Esta es la lista de proveedores actual:\n\n");
                            await MostrarListaDeProveedoresAsync();
                            Console.Clear();
                            Console.Write("Ingrese el nombre de la compañía: ");
                            string suplierCompanyName = Console.ReadLine();
                            Console.Write("Ingrese el nombre del contacto: ");
                            string contactName = Console.ReadLine();
                            Console.Write("Ingrese el título de contacto: ");
                            string contactTitle = Console.ReadLine();
                            Console.Write("Ingrese la dirección: ");
                            string address = Console.ReadLine();
                            Console.Write("Ingrese la ciudad: ");
                            string city = Console.ReadLine();
                            Console.Write("Ingrese la región: ");
                            string region = Console.ReadLine();
                            Console.Write("Ingrese el código postal: ");
                            string postalCode = Console.ReadLine();
                            Console.Write("Ingrese el país: ");
                            string country = Console.ReadLine();
                            Console.Write("Ingrese el número de teléfono: ");
                            string supplierPhone = Console.ReadLine();
                            Console.Write("Ingrese el número de fax: ");
                            string fax = Console.ReadLine();
                            Console.Write("Ingrese la página de inicio: ");
                            string homePage = Console.ReadLine();

                            var nuevoSupplier = new Suppliers
                            {
                                CompanyName = suplierCompanyName,
                                ContactName = contactName,
                                ContactTitle = contactTitle,
                                Address = address,
                                City = city,
                                Region = region,
                                PostalCode = postalCode,
                                Country = country,
                                Phone = supplierPhone,
                                Fax = fax,
                                HomePage = homePage,
                            };
                            await suppliersLogic.AddAsync(nuevoSupplier);

                            Console.WriteLine("Gracias por añadir un transportista, esta es la lista actualizada:\n");
                            await MostrarListaDeProveedoresAsync();

                            break;

                        case 7:
                            Console.Clear();
                            Console.WriteLine("Esta es la lista de proveedores actual:");
                            await MostrarListaDeProveedoresAsync();

                            Console.Write("\nIngrese el ID del proveedor que desea eliminar: ");
                            int idProveedor = Convert.ToInt32(Console.ReadLine());
                            int existSupplierDelete = await suppliersLogic.checkExist(idProveedor);
                            if (existSupplierDelete > 0)
                            {
                                Console.Clear();
                                Console.Write($"Si está seguro de eliminar el transportista de ID {idProveedor} oprima 1, para cancelar 0.");
                                int eliminarProveedor = Convert.ToInt32(Console.ReadLine());
                                if (eliminarProveedor == 1)
                                {
                                    await suppliersLogic.DeleteAsync(idProveedor);
                                    Console.Clear();
                                    Console.WriteLine("Gracias por eliminar el transportista, esta es la lista actualizada:\n");
                                    await MostrarListaDeProveedoresAsync();
                                }
                                else Console.WriteLine("Gracias por recapacitar.");
                            }
                            else Console.WriteLine("La ID ingresada no existe");

                            break;

                        case 8:
                            Console.Clear();
                            Console.WriteLine("Esta es la lista de proveedores actual:\n\n");
                            await MostrarListaDeProveedoresAsync();

                            Console.Write("\n\nIngresá el ID del proveedor que vas a modificar: ");
                            int updateSupplierID = int.Parse(Console.ReadLine());
                            int existSupplier = await suppliersLogic.checkExist(updateSupplierID);
                            if (existSupplier > 0)
                            {
                                Console.Write("Ingrese el nombre de la compañía: ");
                                string updateSuplierCompanyName = Console.ReadLine();
                                Console.Write("Ingrese el nombre del contacto: ");
                                string updateContactName = Console.ReadLine();
                                Console.Write("Ingrese el título de contacto: ");
                                string updateContactTitle = Console.ReadLine();
                                Console.Write("Ingrese la dirección: ");
                                string updateAddress = Console.ReadLine();
                                Console.Write("Ingrese la ciudad: ");
                                string updateCity = Console.ReadLine();
                                Console.Write("Ingrese la región: ");
                                string updateRegion = Console.ReadLine();
                                Console.Write("Ingrese el código postal: ");
                                string updatePostalCode = Console.ReadLine();
                                Console.Write("Ingrese el país: ");
                                string updateCountry = Console.ReadLine();
                                Console.Write("Ingrese el número de teléfono: ");
                                string updateSupplierPhone = Console.ReadLine();
                                Console.Write("Ingrese el número de fax: ");
                                string updateFax = Console.ReadLine();
                                Console.Write("Ingrese la página de inicio: ");
                                string updateHomePage = Console.ReadLine();

                                await suppliersLogic.UpdateAsync(new Suppliers
                                {
                                    SupplierID = updateSupplierID,
                                    CompanyName = updateSuplierCompanyName,
                                    ContactName = updateContactName,
                                    ContactTitle = updateContactTitle,
                                    Address = updateAddress,
                                    City = updateCity,
                                    Region = updateRegion,
                                    PostalCode = updatePostalCode,
                                    Country = updateCountry,
                                    Phone = updateSupplierPhone,
                                    Fax = updateFax,
                                    HomePage = updateHomePage,
                                });
                                Console.Clear();
                                Console.WriteLine($"\n\nGracias por modificar un transportista, esta es la lista actualizada:\n");
                                await MostrarListaDeProveedoresAsync();
                            }
                            else Console.WriteLine("ID inválido, presione alguna tecla para continuar");

                            break;


                        case 9:
                            salida = 1;
                            break;

                        default:
                            Console.WriteLine("Ups!! parece que ingresaste una opción incorrecta!\n\n");
                            break;

                    }
                }


            
            catch (FormatException)
            {
                Console.WriteLine("¡La respuesta tenía que ser sólo con números!\n Presione alguna tecla para continuar.");
            }
            Console.ReadLine();
        }
        while (salida == 0) ;
            {
                Console.WriteLine("Gracias por corregirme :D");

            }

            async Task MostrarListaDeTransportistasAsync()
            {
                var shippersList = await shippersLogic.GetAllAsync();
                foreach (Shippers shippers in shippersList)
                {
                    Console.WriteLine($"{shippers.ShipperID} - {shippers.CompanyName} - {shippers.Phone}");
                }
            }

            async Task MostrarListaDeProveedoresAsync()
            {
                var suppliersList = await suppliersLogic.GetAllAsync();
                foreach (Suppliers suppliers in suppliersList)
                {
                    Console.WriteLine($"{suppliers.SupplierID} - {suppliers.CompanyName} - {suppliers.ContactName} - {suppliers.ContactTitle} - {suppliers.Address} - {suppliers.City} - {suppliers.Region} - {suppliers.PostalCode} - {suppliers.Country} - {suppliers.Phone} - {suppliers.Fax} - {suppliers.HomePage}");
                }
            }
        }
    }
}
