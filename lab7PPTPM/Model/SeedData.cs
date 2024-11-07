using lab7PPTPM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace lab7PPTPM.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new lab7PPTPMContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<lab7PPTPMContext>>()))
            {
                if (context == null || context.Employee == null)
                {
                    throw new ArgumentNullException("Null ApplicationDbContext");
                }

                // Проверяем, есть ли уже сотрудники
                if (context.Employee.Any())
                {
                    return;   // БД уже инициализирована
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        EmployeeSurname = "Ivanov",
                        EmployeeName = "Ivan",
                        EmployeePatronymic = "Ivanovich",
                        EmployeeLogin = "ivanov",
                        EmployeePassword = "password123", // Для примера, лучше использовать хеширование
                        PositionJobId = 1 // Предполагается, что есть позиция с ID 1
                    },
                    new Employee
                    {
                        EmployeeSurname = "Petrov",
                        EmployeeName = "Petr",
                        EmployeePatronymic = "Petrovich",
                        EmployeeLogin = "petrov",
                        EmployeePassword = "password123",
                        PositionJobId = 2 // Предполагается, что есть позиция с ID 2
                    },
                    new Employee
                    {
                        EmployeeSurname = "Sidorov",
                        EmployeeName = "Sidor",
                        EmployeePatronymic = null, // Необязательное поле
                        EmployeeLogin = "sidorov",
                        EmployeePassword = "password123",
                        PositionJobId = 1
                    }
                );

                context.SaveChanges();
                if (context == null || context.PositionJob == null)
                {
                    throw new ArgumentNullException("Null YourDbContext");
                }

                // Проверяем, есть ли уже должности в базе данных
                if (context.PositionJob.Any())
                {
                    return;   // База данных уже инициализирована
                }

                context.PositionJob.AddRange(
                    new PositionJob
                    {
                        PositionJobId = 1,
                        PositionName = "Учитель начальных классов"
                    },

                    new PositionJob
                    {
                        PositionJobId = 2,
                        PositionName = "Учитель математики"
                    },

                    new PositionJob
                    {
                        PositionJobId = 3,
                        PositionName = "Учитель истории"
                    },

                    new PositionJob
                    {
                        PositionJobId = 4,
                        PositionName = "Учитель физики"
                    },

                    new PositionJob
                    {
                        PositionJobId = 5,
                        PositionName = "Учитель иностранных языков"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
