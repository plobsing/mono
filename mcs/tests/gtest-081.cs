public class ArrayList<T>
{
        void AddAll<U> (U u)
		where U : T
        {
		InsertAll (u);
        }

	void InsertAll (T t)
	{ }
}

class X
{
	static void Main ()
	{ }
}
