// Address class
class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInKenya()
    {
        return country.Trim().ToUpper() == "KE"; //short form for Kenya (KE)
    }

    public string GetFullAddress() //Generates full address and returns Street, City,province and country
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}