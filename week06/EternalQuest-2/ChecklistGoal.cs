public class ChecklistGoal : Goal
{
    private int _amountCompleted;

    private int _target;

    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int GetPoints()
    {
        if (_amountCompleted >= _target)
        {
            return base.GetPoints() + _bonus;
        }

        return base.GetPoints();
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }

        return false;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override string GetStringRepresentation()
    {
        // ChecklistGoal : shortname | description | points | bonus | target | amountCompleted
        return $"ChecklistGoal:{GetShortName()}|({GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted})";
    }

    public override string GetDetailsString()
    {
        string detailsStringBase = base.GetDetailsString();
        return $"{detailsStringBase} -- Currently completed: {_amountCompleted}/{_target}";
    }
}