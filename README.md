# iex
Naive implementation of some IEnumerable Extensions

ToCsv(bool withHeaders)
-----
Takes an IEnumerable and converts it into a CSV string.  Will add headers using the property name as the header if withHeaders is true.