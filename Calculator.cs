//Calculator logic

public class Calculator
{
    private  string sName;
    public string Name {
        
        get {if (string.IsNullOrWhiteSpace(sName)) //If name field is empty or whitespace, then set deafault name
        {
            Name = "Default Calculator";
        }
            else
            {
                Name = sName; //Assign var Name to private var sName and return sNme
            }
            return sName; } 
        set
        {
            sName = value; //Set private var to value input
        }}
    public int Result {get; set;}

    public enum OperationType
    {
        Add,
        Sub,
        Multi,
        Divide
        
    }

    public Calculator (string s)
    {
        Name = s; //Overkill?
        
     
    }

    public Calculator ()
    {
        Name = "Default Calculator"; //Overkill if IsNullOrEmpty already implemented
    }

    public double calculate(int a, int b, OperationType operation)
    {
        switch(operation){
            case OperationType.Add:
                return a + b;
                break;
            
            case OperationType.Sub:
                return a - b;
                break;
            case OperationType.Multi:
                return a * b;
                break;
            case OperationType.Divide:
                return (double) a / b;

            default:
                throw new InvalidOperationException();
        }
    }

}