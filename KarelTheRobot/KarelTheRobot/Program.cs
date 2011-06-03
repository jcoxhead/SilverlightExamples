using System;
using System.Linq;
using System.Data;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Implementation;
using FizzWare.NBuilder.PropertyNaming;
using KarelRobotCore.Interfaces;
using KarelTheRobotLib;
using KarelTheRobotLib.DTO;
using KarelTheRobotLib.Factories;

using System;

namespace KarelTheRobot
{
    class Program
    {
        private const int NoOfAvenues = 5;
        private const int NoOfStreets = 5;

        static void Main(string[] args)
        {
            Run();
            GenerateFizzWare();
        }

        private static void GenerateFizzWare()
        {
            // var generator = new UniqueRandomGenerator();

            var namer = new RandomValuePropertyNamer(new RandomGenerator(),
                new ReflectionUtil(),
                true,
                DateTime.Now,
                DateTime.Now.AddDays(5),
            true);

            BuilderSetup.SetDefaultPropertyNamer(namer);

            int sequenceNumber = 1;
            var products = Builder<Product>.CreateListOfSize(20)
               .WhereAll()
                    .Have(q => q.Description = "Description")
                     .And(x => x.ProductCode = "AA-" + sequenceNumber++)
                .Build();

            Action<Product> action = new Action<Product>((q) => Console.WriteLine(q.ProductCode));

            products.ToList().ForEach(action);
        }

        private static void Run()
        {
            // Please note intentional use of fluent interface 
            IWorld world = new World(NoOfAvenues, NoOfStreets);

            var robot = new RobotFactory().CreateRobot(world);

            robot.Move();
            robot.PutBeeper();
            robot.PickBeeper();
            robot.Move();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.Move();
            robot.Move();
            robot.PutBeeper();

            if (robot.NoBeepersPresent())
                robot.PutBeeper();

            robot.PickBeeper();
        }
    }
}
