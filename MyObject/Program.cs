// See https://aka.ms/new-console-template for more information



var myObj = new MyObject("original", new NestedObjectProp("nestedPropA", "nestedPropB"));

var myObjClone = new MyObject(myObj);

myObjClone.ObjectProp = "changed objectProp on clone";
myObjClone.NestedObjectProp.NestedPropB = "changed nestedPropB on clone";



public class MyObject
{
    public MyObject(string objectProp, NestedObjectProp nestedObjectProp)
    {
        this.ObjectProp = objectProp;
        this.NestedObjectProp = nestedObjectProp;
    }

    public MyObject(MyObject other)
    {
        this.ObjectProp = other.ObjectProp;
        this.NestedObjectProp = new NestedObjectProp(other.NestedObjectProp);
    }

    public string ObjectProp { get; set; }
    public NestedObjectProp NestedObjectProp { get; set; }
}

public class NestedObjectProp
{
    public NestedObjectProp(string nestedPropA, string nestedPropB)
    {
        this.NestedPropB = nestedPropB;
        this.NestedPropA = nestedPropA;
    }

    public NestedObjectProp(NestedObjectProp other)
    {
        this.NestedPropA = other.NestedPropA;
        this.NestedPropB = other.NestedPropB;
    }

    public string NestedPropA { get; set; }
    public string NestedPropB { get; set; }
}