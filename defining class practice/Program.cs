using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defining_class_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your Mom Said You Can Have A Pet!!!!");
            Console.WriteLine("What pet would you like?");
            string species = Console.ReadLine();
            
           
            //Console.WriteLine("Does your pet have a tail? True or False");
            //bool tail = bool.Parse(Console.ReadLine());
                
                
            Console.WriteLine("How many legs does your pet have?");
            int legs = int.Parse(Console.ReadLine());

            Console.WriteLine("All our Pets already eat lettuce, cheese and grapes");
            Console.WriteLine("What other food do you want your pet to eat?");
            string userFood1 = Console.ReadLine();
            Console.WriteLine("The more the better! Pick another food");
            string userFood2 = Console.ReadLine();
            Console.WriteLine("Your animal needs a balanced meal, pick a healthy food!");
            string userFood3 = Console.ReadLine();
            Console.WriteLine("Your animal needs one more! Give your pet a snack food");
            string userFood4 = Console.ReadLine();


            List<string> foods = new List<string>();

            List<string> exercise = new List<string>();
            Animal userAnimal = new Animal(species, legs, foods,exercise);
            userAnimal.AddFavoriteFood(userFood1);
            userAnimal.AddFavoriteFood(userFood2);
            userAnimal.AddFavoriteFood(userFood3);
            userAnimal.AddFavoriteFood(userFood4);
            userAnimal.AddFavoriteFood("lettuce");
            userAnimal.AddFavoriteFood("cheese");
            userAnimal.AddFavoriteFood("grapes");
            Console.WriteLine("************************************");
            userAnimal.ListFavoriteFood();   
            
            userAnimal.AddExercises("Walk");
            userAnimal.AddExercises("Run");
            userAnimal.AddExercises("Jump");
            userAnimal.AddExercises("Play");

            Console.WriteLine("**************************************");
            userAnimal.ListExercises();
            string userExercise = Console.ReadLine();
            userExercise = userExercise.ToUpper();
            userAnimal.Exercise(userExercise);
           
            //Animal dumbo = new Animal("elephant", 4, new List<string> { "bananas", "grass" }, true);

            
            //Console.WriteLine("hunger initial = " + dumbo.Hunger);
            //dumbo.Feed();
            //Console.WriteLine("hunger after feeding = " + dumbo.Hunger);

           //// dumbo.WorkOut();
           // Console.WriteLine("hunger after working out= " + dumbo.Hunger);

           // dumbo.AddFavoriteFood("apples");
           // dumbo.AddFavoriteFood("celery");
           // dumbo.ListFavoriteFood();
            
            
           
        }   
    }
    class Animal//creating a class
    {
        //inside body is fields/ are typically the access modifier is private
        private int legs = 4;
        private string species = "unknown";
        private List<string> favoriteFoods = new List<string>();
        private bool hasTail = true;
        private int hunger = 10;
        private const int maxFul = 10;
        private Random random = new Random();

        private List<string> exerciseMenu = new List<string>();
            
        //properties
        public int Legs
        {//get allows the user to retrieve data
            get
            {//to identify the field legs with 'this'
                return this.legs;
            }
            set
            {//value holds the users info on legs in the main
                //Properties is mom and fiels is a baby. Properties protect fields from being messed with
                this.legs = value;
            }

        }
        public string Species
        {
            get
            {
                return this.species;
            }
            set
            {
                this.species = value;
            }
        }
        public List<string> FavoriteFoods
        {
            get { return this.favoriteFoods; }
            set { this.favoriteFoods = value; }
        }
        public List<string> AnimalExercises
        {
            get { return this.exerciseMenu; }
            set { this.exerciseMenu = value; }
        }
        public bool HasTail
        {
            get { return this.hasTail; }
            set { this.hasTail = value; }
        }
        public int Hunger
        {
            get { return this.hunger; }
            set
            {
                if (value >= maxFul)
                {
                    Console.WriteLine(this.Species + " is full");
                }
                this.hunger = System.Math.Min(value,maxFul);
                
            }
        }
        internal void AddExercises(string exerciseItem)
        {
            this.AnimalExercises.Add(exerciseItem);
        }
        public void ListExercises()
        {
            Console.WriteLine("your " + this.Species + " loves these exercises,\nchoose which exercise your pet should do!");
            foreach(string favexerc in this.AnimalExercises)
            {
                Console.WriteLine(favexerc);
            }
        }
        public void Exercise(string exercise)
        {
            switch (exercise)
            {
                case "WALK":                                         
                    this.Hunger = this.Hunger -2;                                         
                    Console.WriteLine("He's hungry, Let's feed him something");
                    break;
                case "RUN":
                    this.Hunger = this.Hunger -4;
                    Console.WriteLine("Running made him very hungry! Lets feed your animal");
                    break;
                case "JUMP":
                    this.Hunger = 7;
                    Console.WriteLine("Great workout, your animal needs to eat!");
                    break;
                case "PLAY":
                    this.Hunger = 9;                     
                    Console.WriteLine("That was fun! Your animal deserves a treat!");
                    break;
            }
            //refactor later
            //feed until full
            FeedUntilFull();
        }

        public void FeedUntilFull()
        {
            do
            {
                Feed();
            }
            while (Hunger < maxFul);
        }
       
        //methods
        /*public string WorkOut(string dayWorkout)
        {
            string[] days = {"Monday", "Tuesday", "Wednsday", "Thursday", "Friday", "Saturday", "Sunday" };
           Console.Write(days.Length);

            Random randomDay = new Random();
            int randomNum = randomDay.Next(days.Length);
            return days[randomNum];
        }*/
        public bool Feed()
        {
            //get random food because nothis was specified
            int randomNum = random.Next(this.FavoriteFoods.Count);
            Console.WriteLine(this.Species +" just ate " + this.FavoriteFoods.ElementAt(randomNum));
            this.Hunger += CheckFoodValue(this.FavoriteFoods.ElementAt(randomNum));
            return true;
            
        }
        public int CheckFoodValue(string foodItem)
        {
            return 1;
        }
        internal void AddFavoriteFood(string foodItem)
        {
            this.FavoriteFoods.Add(foodItem);
        }
        public void ListFavoriteFood()
        {
            Console.WriteLine(this.Species + "  Favorite foods include");
            foreach(string favFood in this.FavoriteFoods)
            {
                Console.WriteLine(favFood);
            }
        }
        //constructors
        public Animal()
        {
            //this constructor will default to the fields
        }
        public Animal(string animalSpecies, int legs, List<string> food, List<string>exercise)
        {
            this.Species = animalSpecies;
            this.Legs = legs;
            this.FavoriteFoods = food;
            this.AnimalExercises = exerciseMenu;
        }
        public Animal(string animalSpecies, int Legs, List<string> food, bool hasTail)
        {
            this.Species = animalSpecies;
            this.Legs = legs;
            this.FavoriteFoods = food;
            this.HasTail = hasTail;
        }
        
        
        
    }
}
