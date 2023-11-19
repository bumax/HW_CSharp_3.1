using HW_CSharp_3._1;

internal class Program
{
    private static void Main(string[] args)
    {
        FamilyMember tree = new FamilyMember();
        GenerateRandomTree(3, tree);
        tree.PrintTree();
    }
    
    private static void GenerateRandomTree(int depth, FamilyMember member) { 
        if (depth > 0)
        {
            Random rnd = new Random();
            depth--;
            member.Father = new FamilyMember();
            member.Mother = new FamilyMember();
            FamilyMember father = member.Father;
            FamilyMember mother = member.Mother;
            member.Name = "Name" + rnd.Next().ToString();
            father.Sex = Gender.Male;
            mother.Sex = Gender.Female;
            GenerateRandomTree(depth, father);
            GenerateRandomTree(depth, mother);
        }
    
    }
}