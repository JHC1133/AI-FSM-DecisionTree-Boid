using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class DT
    {
        public DecisionQuery root;

        public DT() 
        {
            root = MainDecisionTree();
        }


        public abstract class Decision
        {
            public abstract void Evaluate(Dog dog);
        }

        public class DecisionQuery : Decision
        {
            public Decision Positive { get; set; }
            public Decision Negative { get; set; }
            public Func<Dog, bool> Test { get; set; }
            public Func<Dog, bool> DisableMoveMode { get; set; }
            public Func<Dog, bool> DisableRageMode { get; set; }
            public Func<Dog, bool> DisableDrinkMode { get; set; }
            public Func<Dog, bool> DisablePeeMode { get; set; }

            public override void Evaluate(Dog dog)
            {
                bool result = this.Test(dog);
                if (result)
                {
                    this.DisableMoveMode(dog);
                    this.DisableDrinkMode(dog);
                    this.DisableRageMode(dog);
                    this.DisablePeeMode(dog);
                    this.Positive.Evaluate(dog);
                }
                else
                {
                    this.DisableMoveMode(dog);
                    this.DisableDrinkMode(dog);
                    this.DisableRageMode(dog);
                    this.DisablePeeMode(dog);
                    this.Negative.Evaluate(dog);
                }
            }
        }

        public class DecisionResult : Decision
        {
            public bool Result { get; set; }

            public override void Evaluate(Dog dog)
            {
                
            }
        }

        private static DecisionQuery MainDecisionTree()
        {
            var moveModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.moveMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false },
                DisableMoveMode = (dog) => dog.moveMode = true,
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false,
                DisableRageMode = (dog) => dog.rageMode = false
                
            };

            var rageModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.rageMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false },
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisableRageMode = (dog) => dog.rageMode = true
            };

            var peeModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.peeMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false },
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisableRageMode = (dog) => dog.rageMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisablePeeMode = (dog) => dog.peeMode = true
            };

            var drinkModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.drinkMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false },
                DisableRageMode = (dog) => dog.rageMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisableDrinkMode = (dog) => dog.drinkMode = true
            };

            //Is peetimer zero?
            var peeQueryBranch = new DecisionQuery
            {
                Test = (dog) => dog.isPeeTimerZero,
                Positive = peeModeBranch,
                Negative = moveModeBranch,
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisableRageMode = (dog) => dog.rageMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false
            };

            //Is there water?
            var waterQueryBranch = new DecisionQuery
            {
                Test = (dog) => dog.isThereWater,
                Positive = drinkModeBranch,
                Negative = rageModeBranch,
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisableRageMode = (dog) => dog.rageMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false
            };

            //Root: Is dog thirsty?
            var root = new DecisionQuery
            {
                Test = (dog) => dog.isDogThirsty,
                Positive = waterQueryBranch,
                Negative = peeQueryBranch,
                DisableDrinkMode = (dog) => dog.drinkMode = false,
                DisableRageMode = (dog) => dog.rageMode = false,
                DisableMoveMode = (dog) => dog.moveMode = false,
                DisablePeeMode = (dog) => dog.peeMode = false

            };

            return root;
        }
    }
}
