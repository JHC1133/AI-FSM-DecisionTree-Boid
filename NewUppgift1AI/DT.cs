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
            public Func<Dog, bool> Action { get; set; }

            public override void Evaluate(Dog dog)
            {
                bool result = this.Test(dog);
                if (result)
                {
                    this.Positive.Evaluate(dog);
                }
                else
                {
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
                Test = (dog) => dog.moveMode = false,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false }
            };

            var rageModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.rageMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false }
            };

            var peeModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.peeMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false }
            };

            var drinkModeBranch = new DecisionQuery
            {
                Test = (dog) => dog.drinkMode = true,
                Positive = new DecisionResult { Result = true },
                Negative = new DecisionResult { Result = false }
            };

            //Is peetimer zero?
            var peeQueryBranch = new DecisionQuery
            {
                Test = (dog) => dog.isThePeeTimerZero,
                Positive = peeModeBranch,
                Negative = moveModeBranch
            };

            //Is there water?
            var waterQueryBranch = new DecisionQuery
            {
                Test = (dog) => dog.isThereWater,
                Positive = drinkModeBranch,
                Negative = rageModeBranch
            };

            //Root: Is dog thirsty?
            var root = new DecisionQuery
            {
                Test = (dog) => dog.isDogThirsty,
                Positive = waterQueryBranch,
                Negative = peeQueryBranch
            };

            return root;
        }
    }
}
