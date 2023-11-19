using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CSharp_3._1
{
    public enum Gender
    {
        Male,
        Female
    }
    public class FamilyMember
    {
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }

        void Info(int indent = 0)
        {
            Console.WriteLine($"{new String('-', indent)}Имя {this.Name}");
        }
        public virtual void Print(int indent = 0)
        {
            Info(indent);
        }
        public void PrintTree()
        {
            PrintTreeRecurcive(this, Console.WindowWidth/2);
        }
        private void PrintTreeRecurcive(FamilyMember memeber, int x, int y = 0)
        {
            int n = Convert.ToInt32(Console.WindowWidth / (Math.Pow(2.0, Convert.ToDouble(y+1)) + 1 ) / 2);
            Console.SetCursorPosition(x, y);
            Console.Write(memeber.Name);
            if (memeber.Father.Name != null)
            {
                Console.SetCursorPosition(x - 1, y);
                Console.Write('┌');
                PrintTreeRecurcive(memeber.Father, x - n, y + 1);
            }
            if (memeber.Mother.Name != null)
            {
                Console.SetCursorPosition(x + memeber.Name.Length, y);
                Console.Write('┐');
                PrintTreeRecurcive(memeber.Mother, x + n, y + 1);
            }
        }


    }
    public class AdultFamilyMember : FamilyMember
    {
        public FamilyMember[] Children { get; set; }
        public override void Print(int indent = 0)
        {
            base.Print(indent);

            foreach (var child in Children)
                child.Print(indent * 2);
        }

    }

    
}
