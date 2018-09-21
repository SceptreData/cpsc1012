using System;

namespace CorePortfolio1
{  
    /*
     * Purpose: To determine the amount of materials and cost required to build a fence.
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
     * Process: -fenceArea
     *          -gateArea
     *          - fencePerimiter
     *          -numPosts
     *          -railingLength
     *          -quartsOfPaint
     *          -subTotal
     *          -taxAmount
     *          -totalCost
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
     * Date Modified: 2018.09.17
     * */
    class Program
    {
        static void Main(string[] args)
        {
            // Declare my Constants
            const double TAX_RATE = 0.05;
            const double PAINT_PRICE = 15.99;
            const double PAINT_SQFT_PER_BUCKET = 400;

            const double FENCE_SQFT_PRICE = 7.25;
            const double POST_PRICE = 23.99;
            const double RAIL_PRICE_PER_FOOT = 0.69;

            const double GATE_FIXED_PRICE = 120;
            const double GATE_SQFT_PRICE = 15.75;

            // Declare inputs.
            double fenceLength;
            double fenceWidth;
            double fenceHeight;

            double postDistance; // Distance between posts

            double gateWidth;
            double gateHeight;

            // Declare Process variables (Stuff we need to calculate)
            double
            double
            double
            double
            double
            double

        }
    }
}
