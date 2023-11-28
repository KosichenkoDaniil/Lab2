using lab_2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TouristAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Выборка всех сотрудников");
                Console.WriteLine("2. Выборка сотрудников, родившиеся до 1993 года, не найдены.");
                Console.WriteLine("3. Вывести группированные данные о депозитах");
                Console.WriteLine("4. Вывести валюту и ретинг обмена");
                Console.WriteLine("5. Вывести данные о вкладах, сумма которых больше 2000");
                Console.WriteLine("6. Добавить нового клиента");
                Console.WriteLine("7. Добавить операции");
                Console.WriteLine("8. Удалить клиента");
                Console.WriteLine("9. Удалить операцию");
                Console.WriteLine("10. Обновить вклады");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AllEmployees();
                            break;
                        case 2:
                            employeesBornBefore1993();
                            break;
                        case 3:
                            GroupedDepositsByPrice();
                            break;
                         case 4:
                            DisplayCurrencyAndPrice();
                            break;
                        case 5:
                            OperationsWithHighMindepositamount();
                             break;
                        case 6:
                            AddNewInvestor();
                            break;
                        case 7:
                            AddNewOperation();
                            break;
                        case 8:
                            DeleteInvestor();
                            break;
                        case 9:
                            DeleteOperation();
                            break;
                        case 10:
                            UpdateDeposits();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите снова.");
                }
            }

        }
        static void AllEmployees()
        {
            using (var context = new BankDeposits1Context()) // Вывод данных о сотрудниках
            {
                var employees = context.Emploees.ToList();

                if (employees.Count > 0)
                {
                    Console.WriteLine("Вся информация о сотрудниках:");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id} | Имя: {employee.Name} | Фамилия: {employee.Surname} | Отчество: {employee.Middlename} | Должность: {employee.Post} | Дата рождения: {employee.Dob}");
                    }
                }
                else
                {
                    Console.WriteLine("Сотрудники не найдены.");
                }
            }
        }

        static void employeesBornBefore1993()
        {
            using (var context = new BankDeposits1Context())
            {
                var selectedEmployees = context.Emploees
                    .Where(employee => employee.Dob.Year > 1993)
                    .ToList();

                if (selectedEmployees.Count > 0)
                {
                    Console.WriteLine($"Сотрудники, родившиеся после 1993 года:");
                    foreach (var employee in selectedEmployees)
                    {
                        Console.WriteLine($"ID: {employee.Id} | Имя: {employee.Name} | Фамилия: {employee.Surname} | Отчество: {employee.Middlename} | Должность: {employee.Post} | Дата рождения: {employee.Dob}"); ;
                    }
                }
                else
                {
                    Console.WriteLine($"Сотрудники, родившиеся до 1993 года, не найдены.");
                }
            }
        }


        static void GroupedDepositsByPrice()
        {
            using (var context = new BankDeposits1Context()) // Группирует по цене депозитов
            {
                var groupedDeposits = context.Deposits
                    .GroupBy(deposit => deposit.Mindepositamount)
                    .Select(group => new
                    {
                        Price = group.Key,
                        MaxPrice = group.Max(deposit => deposit.Mindepositamount),
                        Count = group.Count()
                    })
                    .ToList();

                foreach (var group in groupedDeposits)
                {
                    Console.WriteLine($"Цена услуги: {group.Price.ToString("N2")} | Максимальная цена: {group.MaxPrice.ToString("N2")} | Количество услуг: {group.Count}");
                }
            }
        }

        static void DisplayCurrencyAndPrice()
        {
            using (var context = new BankDeposits1Context())
            {
                var currencyRates = context.Exchangerates
                    .Select(rate => new
                    {
                        CurrencyName = rate.Currency.Name,
                        ExchangeRateCost = rate.Cost
                    })
                    .ToList();

                foreach (var entry in currencyRates)
                {
                    Console.WriteLine($"Валюта: {entry.CurrencyName}, Цена обмена: {entry.ExchangeRateCost}");
                }
            }
        }

        static void OperationsWithHighMindepositamount()
            {
                using (var context = new BankDeposits1Context()) 
                {
                    decimal minimumDeposit = 2000.0m;

                    var vouchersWithHighValueDeals = context.Operations
                        .Where(operation =>
                            operation.Deposit.Mindepositamount > minimumDeposit)
                        .ToList();

                    foreach (var deposit in vouchersWithHighValueDeals)
                    {
                        Console.WriteLine($"Вклады, стоимость которых свыше {minimumDeposit:N2} | Номер вклада: {deposit.Id}");
                    }
                }
            }

        static void AddNewInvestor()
        {
            using (var context = new BankDeposits1Context()) // Добавление нового клиента
            {
                var newInvestor = new Investor
                {
                    Name = "Василий",
                    Surname = "Король",
                    Middlename = "Николаевич",
                    Address = "пр. Ленина, 69",
                    Phonenumber = "6969696969",
                    PassportId = "HB69696969",
                };

                context.Investors.Add(newInvestor);
                context.SaveChanges();

                Console.WriteLine("Новый клиент успешно добавлен.");
            }
        }

        static void AddNewOperation()
        {
            using (var context = new BankDeposits1Context()) // Добавление новой записи в путёвки
            {
                var newOperation = new Operation
                {
                    Investorsid = 1,
                    Depositdate = DateTime.Now,
                    Returndate = DateTime.Now.AddDays(180),
                    Depositid = 1,
                    Depositamount = 4724,
                    Refundamount = 2757,
                    Returnstamp = false,
                    Emploeeid = 1,
                };

                context.Operations.Add(newOperation); // Добавление новой операции
                context.SaveChanges(); // Сохранение изменений

                Console.WriteLine("Новая операции успешно создана.");
            }
        }


        static void DeleteInvestor()
        {
            using (var context = new BankDeposits1Context()) // Удаление записи по фамилии
            {
                var investorToDelete = context.Investors.FirstOrDefault(i => i.Surname == "Король");

                if (investorToDelete != null)
                {
                    context.Investors.Remove(investorToDelete); // Удаление клиента из контекста базы данных
                    context.SaveChanges(); // Сохранение изменений

                    Console.WriteLine("Клиент успешно удален.");
                }
                else
                {
                    Console.WriteLine("Клиент не найден.");
                }
            }
        }



        static void DeleteOperation()
        {
            using (var context = new BankDeposits1Context()) // Удаление записи из таблицы Voucher
            {
                var operationToDelete = context.Operations.FirstOrDefault(o => o.Id == 61);

                if (operationToDelete != null)
                {
                    context.Operations.Remove(operationToDelete); // Удаление путёвки из контекста базы данных
                    context.SaveChanges(); // Сохранение изменений

                    Console.WriteLine("Операция успешна удалена.");
                }
                else
                {
                    Console.WriteLine("Операция не найден.");
                }
            }
        }


        static void UpdateDeposits()
        {
            using (var context = new BankDeposits1Context()) // Изменение стоимости услуги
            {
                var depositsToUpdate = context.Deposits.Where(deposit => deposit.Mindepositamount < 700);

                foreach (var deposit in depositsToUpdate)
                {
                    deposit.Mindepositamount *= 1.2m;
                }

                context.SaveChanges();

                Console.WriteLine("Депозиты успешно обновлены.");
            }
        }


    }
}


