namespace CalculatorDomainDemo;


/// <summary>
/// This class represents the DOMAIN BEHAVIOUR.
/// 
/// In real systems:
/// - This is where rules live
/// - This is where decisions are made
/// 
/// In the booking system, this is similar to:
/// - Booking management logic
/// </summary>
public class Calculator
{
    //Fieds
    private readonly List<CalculationRequest> _History = new();



    /// <summary>
    /// This property stores state INSIDE the object.
    /// 
    /// Notice:
    /// - Public getter
    /// - Private setter
    /// 
    /// This means:
    /// - Other code can read the value
    /// - Only the Calculator can change it
    /// 
    /// This protects the object from invalid changes.
    /// </summary>
    /// 
    /// Properties
    
    public IReadOnlyList<CalculationRequest> History
    {
        get {return _History;}              //View calc history
    }
    public int LastResult { get; private set; }


    /// <summary>
    /// Every calculator must have a name.
    /// 
    /// Constructors define what MUST exist
    /// for an object to be valid.
    /// </summary>
    public string Name { get; }

    public Calculator(string name)
    {
        // Guard clause:
        // We do NOT allow invalid objects to exist.
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Calculator must have a name");

        Name = name;
    }

    
    /// <summary>
    /// This method applies business rules.
    /// 
    /// It does NOT:
    /// - Read from the console
    /// - Print output
    /// 
    /// This separation is important because:
    /// - Console apps are temporary
    /// - Business logic must survive
    /// 
    /// In the booking system:
    /// - This would decide if a booking is allowed
    /// - This would enforce capacity rules
    /// </summary>
    public int Calculate(int a, int b, OperationType operation)
    {
        // Switch expression ensures ALL enum cases are handled
        LastResult = operation switch
        {
            OperationType.Add => a + b,
            OperationType.Subtract => a - b,
            OperationType.Multiply => a * b,
            OperationType.Divide => a / b,


            // This should never happen if enums are used correctly
            _ => throw new InvalidOperationException("Invalid operation")
        };

        CalculationRequest request = new CalculationRequest(a,b, operation);
        _History.Add(request);

        return LastResult;
    }


    //Get the addition operations were done on this calc

    public List<CalculationRequest> ReturnAdditions ()
    {
        List<CalculationRequest> Additions = new List<CalculationRequest> ();
        foreach (CalculationRequest req in _History)
        {
            if (req.Operation == OperationType.Add)
            {
                Additions.Add(req);
            }
        }
        return Additions;

    }

    //Same, but use LINQ
    public List <CalculationRequest> ReturnDivide()
    {
        
        List<CalculationRequest> req = _History.Where(i  => i.Operation == OperationType.Divide).ToList();
        
        return req;
    }

    //Has Division ever been used?
    public bool HasDivisionBeenUsed()
    {
        bool div = _History.Any(i  => i.Operation == OperationType.Divide);
        
        return div;
    }

    //Writing cutom exceptions
    public double Divide(CalculationRequest request1)
    {
        if(request1.B == 0)
        {
            throw new InvalidOperationException("Division cannot be don because the denominatoris 0");
        }
        else
        {
            return request1.A/ request1.B;
        }
    }


}