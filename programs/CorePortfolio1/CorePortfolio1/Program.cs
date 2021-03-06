﻿using System;

namespace CorePortfolio1
{
    /*
     * Purpose: To determine the amount of materials and cost required to build a playground fence.
     *          
     * Input: Rectangular Playground dimensions (in Feet):
     *          - fenceLength
     *          - fenceWidth
     *          - fenceHeight
     *        Gate Dimensions
     *          - gateWidth
     *          - gateHeight
     *        Distance between Posts (in Feet)
     *          - postDistance
     *         
     * Process:
     *          - totalPerimeter;
     *          - fencePerimeter;
     *          - fenceSqFt;
     *          - fenceMaterial;
     *          - fenceCost;
     *
     *          - numPosts;
     *          - postCost;
     *
     *          - feetOfRailing;
     *          - railMaterial;
     *          - railCost;
     *
     *          - quartsOfPaint;
     *          - numPaintBuckets;
     *          - paintCost;
     *
     *          - gateMaterial;
     *          - gateCost;
     *
     *          - netPrice;
     *          - taxAmount;
     *          - totalPrice; 
     * 
     *          
     * Output:  Amount of Fencing Material required and Extended Price
     *          Number of Posts required and extended price
     *          Lineal feet of railing required
     *          Amount of paint required and extended price
     *          Number of gates required and extended price
     *          Net Price
     *          Total GST (5%)
     *          Total Price
     *          
     * Written By: David Bergeron
     * Date Modified: 2018.09.30
     * */
    class Program
    {
        static void Main(string[] args)
        {
            // Declare my Constants
            const double WASTE_FACTOR = 1.10;

            const double FENCE_PRICE_PER_SQFT = 7.25;
            const double POST_PRICE = 23.99;
            const double RAIL_PRICE_PER_FOOT = 0.69;

            const double PAINT_PRICE_PER_BUCKET = 15.99;
            const double SQFT_PAINT_PER_QUART = 100;

            const double GATE_FIXED_PRICE = 120;
            const double GATE_PRICE_PER_SQFT = 15.75;

            const double TAX_RATE = 0.05;           

            // Declare inputs.
            double fenceLength;
            double fenceWidth;
            double fenceHeight;
            
            double postDistance; 

            double gateWidth;
            double gateHeight;

            // Declare Process variables (Stuff we need to calculate)
            double totalPerimeter;
            double fencePerimeter;
            double fenceSqFt;
            double fenceMaterial;
            double fenceCost;

            double numPosts;
            double postCost;

            double feetOfRailing;
            double railMaterial;
            double railCost;

            double quartsOfPaint;
            double numPaintBuckets;
            double paintCost;

            double gateMaterial;
            double gateCost;

            double netPrice;
            double taxAmount;
            double totalPrice;

            // Grab our inputs
            Console.Write("Enter the width of the playground\t>> ");
            fenceWidth = double.Parse(Console.ReadLine());

            Console.Write("Enter the length of the playground\t>> ");
            fenceLength = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the fence\t\t>> ");
            fenceHeight = double.Parse(Console.ReadLine());

            Console.Write("Enter the width of the gate\t\t>> ");
            gateWidth = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the gate\t\t>> ");
            gateHeight = double.Parse(Console.ReadLine());

            Console.Write("Enter the space between posts\t\t>> ");
            postDistance = double.Parse(Console.ReadLine());


            /* FENCING MATERIAL CALCULATION
             * We calculate our total fencingMaterial by:
             *    - Calculating the total perimeter of the playground
             *    - Determining perimeter of the fence by subtracting the width of the gate.
             *    - calculating Square Footage of our Fence (fencePerimeter * fenceHeight)
             *    - Making sure to factor in our waste ratio. */
            totalPerimeter = (fenceLength * 2) + (fenceWidth * 2);
            fencePerimeter = totalPerimeter - gateWidth;

            fenceSqFt = fencePerimeter * fenceHeight;
            fenceMaterial = Math.Ceiling(fenceSqFt * WASTE_FACTOR);

            // Now that we know how much fenceMaterial we need, we can calculate the price.
            fenceCost = fenceMaterial * FENCE_PRICE_PER_SQFT;


            /* POST CALCULATIONS 
             * We calculate the number of posts by:
             *   - dividing the lineal footage of the fence by the distance between posts.
             *   - Rounding up the nearest whole number (using Math.Ceiling)
             *   - Adding an extra post for the first corner. */
            numPosts = Math.Ceiling((totalPerimeter / postDistance)) + 1;

            // Calculate the net cost for our posts.
            postCost = numPosts * POST_PRICE;


            /* RAILING CALCULATIONS
             * Calculate how many feet of Railing we need by:
             *   - multiplying our fence perimeter by 2 (for the top rail and the bottom rail)
             *   - multiply our linear feet of railing by the waste factor. */
            feetOfRailing = Math.Ceiling(totalPerimeter * 2);
            railMaterial = feetOfRailing * WASTE_FACTOR;

            // Calculate net cost of our railing.
            railCost = railMaterial * RAIL_PRICE_PER_FOOT;


            /* PAINT CALCULATIONS
             * Calculate how much paint we need by:
             *      - divide the Square Footage of fence we need to paint by 100.
             *         - Need to paint both sides of the fence, so double our fence SquareFootage.
             *         - Each gallon of paint covers 400 SQFT of fence.
             *         - There are 4 Quarts of paint per gallon, so each quart of paint
             *           covers 100 Square Feet of Fence
             *      - Making sure to include our WASTE_FACTOR
             *      - Rounding up to the nearest whole number (We can't buy half a bucket of paint) */
            quartsOfPaint = (fenceSqFt * 2) / SQFT_PAINT_PER_QUART;
            numPaintBuckets = Math.Ceiling( quartsOfPaint );

            // Calculate net cost of our paint.
            paintCost = numPaintBuckets * PAINT_PRICE_PER_BUCKET;


            /* GATE CALCULATIONS
             *  Calculate how much gate material we need by:
             *     - determining Square Footage of our gate (gateWidth * gateHeight) 
             *     - Making sure to include our WASTE_FACTOR */
            gateMaterial = gateWidth * gateHeight;

            // Calculate Net cost for the gate, including fixed cost.
            gateCost = GATE_FIXED_PRICE + (gateMaterial * GATE_PRICE_PER_SQFT);


            /* Total Price Calculations */
            netPrice = fenceCost + postCost + railCost + gateCost + paintCost;
            taxAmount = netPrice * TAX_RATE;

            totalPrice = netPrice + taxAmount;

            /* PRINT THOSE RESULTS */
            Console.WriteLine("\nInvoice and Packing Slip\n");
            Console.WriteLine("  {0,-8:F0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                                             fenceMaterial,
                                             "^ft.",
                                             "Fence Material",
                                             FENCE_PRICE_PER_SQFT,
                                             fenceCost
                                             );
            Console.WriteLine("  {0,-8:F0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                                             numPosts,
                                             "",
                                             "Posts",
                                             POST_PRICE,
                                             postCost
                                             );
            Console.WriteLine("  {0,-8:F0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                                             railMaterial,
                                             "ft.",
                                             "Railing",
                                             RAIL_PRICE_PER_FOOT,
                                             railCost 
                                             );
            Console.WriteLine("  {0,-8:F0} {1,5} {2,-20} @ {3,8} = {4,12:C}",
                                             1.0,
                                             "",
                                             "Gate",
                                             "",
                                             gateCost
                                             );
            Console.WriteLine("  {0,-8:F0} {1,5} {2,-20} @ {3,8:0.00} = {4,12:C}",
                                             numPaintBuckets,
                                             "qts.",
                                             "Paint",
                                             PAINT_PRICE_PER_BUCKET,
                                             paintCost
                                             );

            // Print our Totals
            Console.WriteLine("\n{0,-35} {1, -10}   = {2,12:C}",
                                            " ",
                                            "Net Price",
                                            netPrice);
            Console.WriteLine("{0, -35} {1, -10}   = {2,12:C}",
                                            " ",
                                            "GST",
                                            taxAmount);
            Console.WriteLine("{0, -35} {1, -10}   = {2,12:C}",
                                            " ",
                                            "Total",
                                            totalPrice);
        }
    }
}