// stockPricesYesterday = [10, 7, 5, 8, 11, 9];
//
// GetMaxProfit(stockPricesYesterday)
// # returns 6 (buying for $5 and selling for $11)


//Brute force approach
//Goes through every pair of price elements
//takes O(n^2) time (two nested loops)
//problem: this will never be negative, 
//i.e. instance where price goes down throughout day, 
//because we start at 0
public static double GetMaxProfit(double[] stockPricesYesterday)
{
	double maxProfit = 0.00;

	//loop through each element in array
	for(int i=0;i < stockPricesYesterday.Length(); i++)
	{
		//loop through every other element
		for(int j=0;j < stockPricesYesterday.Length(); j++)
		{
			//for each pair, find the earlier and later times
            earlierTime = Min(i, j);
            laterTime = Max(i, j);

			//for each pair, find earlier & later prices
			earlierPrice = stockPricesYesterday[earlierTime];
            laterPrice = stockPricesYesterday[laterTime];

			//find potential profit between prices
			potentialProfit = laterPrice - earlierPrice;

			//update maxProfit if greater
			maxProfit = Max(maxProfit, potentialProfit);
		}
	}
	return maxProfit;
}


//Brute force approach
//Shorten inner for loop to only go through later prices
//takes O(n^2) time (two nested loops)
//problem: this will never be negative, 
//i.e. instance where price goes down throughout day, 
//because we start at 0
public static double GetMaxProfit(double[] stockPricesYesterday)
{
	double maxProfit = 0.00;

	//loop through each element in array
	for(int i=0;i < stockPricesYesterday.Length(); i++)
	{
		//loop through every other element
		for(int j=i+1;j < stockPricesYesterday.Length()-i; j++)
		{
			//for each pair, find the earlier and later times
            earlierTime = Min(i, j);
            laterTime = Max(i, j);

			//for each pair, find earlier & later prices
			earlierPrice = stockPricesYesterday[earlierTime];
            laterPrice = stockPricesYesterday[laterTime];

			//find potential profit between prices
			potentialProfit = laterPrice - earlierPrice;

			//update maxProfit if greater
			maxProfit = Max(maxProfit, potentialProfit);
		}
	}
	return maxProfit;
}

//Greedy approach
//keep a running maxProfit & minPrice until we reach the end of list
//go through list once, takes O(n) time
//problem: edge cases, e.g. stock goes down all day
public static double GetMaxProfit(double[] stockPricesYesterday)
{
	double maxProfit = 0.00;
	double minPrice = stockPricesYesterday[0];

	//loop through each element in array
	foreach(var currentPrice in stockPricesYesterday)
	{
		//replace minPrice if needed
		minPrice = Min(minPrice, currentPrice);

		//find potentialProfit if bought at minPrice & sold at currentPrice
		potentialProfit = currentPrice - minPrice;

		//update maxProfit if greater
		maxProfit = Max(maxProfit, potentialProfit);
	}
	return maxProfit;
}

//Greedy approach
//keep a running maxProfit & minPrice until we reach the end of list
//go through list once, takes O(n) time
//Problem: if price goes down all day, maProfit stays 0 because currentPrice == minPrice,
//i.e. both buying and selling stocks at the currentPrice
public static double GetMaxProfit(double[] stockPricesYesterday)
{
	//Raise error if
	if(stockPricesYesterday.Length() < 2)
	{
		throw new ValidationException(“Length of stockPricesYesterday array is too short. Must be >= 2.”);
	}

	//start maxProfit at first profit instead of 0
	double maxProfit = stockPricesYesterday[1] - stockPricesYesterday[0];
	double minPrice = stockPricesYesterday[0];

	//loop through each element in array
	foreach(var currentPrice in stockPricesYesterday)
	{
		//replace minPrice if needed
		minPrice = Min(minPrice, currentPrice);

		//find potentialProfit if bought at minPrice & sold at currentPrice
		potentialProfit = currentPrice - minPrice;

		//update maxProfit if greater
		maxProfit = Max(maxProfit, potentialProfit);
	}
	return maxProfit;
}

//Greedy approach
//keep a running maxProfit & minPrice until we reach the end of list
//go through list once, takes O(n) time
//uses O(1) space
//calculate maxProfit before minPrice
//make sure to not buy & sale at time(0)
public static double GetMaxProfit(double[] stockPricesYesterday)
{
	//Raise error if less than two values in array
	if(stockPricesYesterday.Length() < 2)
	{
		throw new ValidationException(“Length of stockPricesYesterday array is too short. Must be >= 2.”);
	}

	//start maxProfit at first profit instead of 0
	double maxProfit = stockPricesYesterday[1] - stockPricesYesterday[0];
	double minPrice = stockPricesYesterday[0];

	//loop through each element in array
	//skip the first (0th) time
	//we can't sell at the first time, since we must buy first, and we can't buy and sell at the same time!
    //if we took Skip(1) out, we'd try to buy *and* sell at time 0.
    //this would give a profit of 0, which is a problem if our
    //max_profit is supposed to be *negative*--we'd return 0.
	foreach(var currentPrice in stockPricesYesterday.Skip(1))
	{
		//find potentialProfit if bought at minPrice & sold at currentPrice
		potentialProfit = currentPrice - minPrice;

		//update maxProfit if greater
		maxProfit = Max(maxProfit, potentialProfit);

		//replace minPrice if needed
		minPrice = Min(minPrice, currentPrice);
	}
	return maxProfit;
}