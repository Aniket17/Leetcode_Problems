public class Solution {
    public string Multiply(string num1, string num2) {
        int m = num1.Length, n = num2.Length;
        
        // Edge case: if either number is "0", the product is "0"
        if (num1 == "0" || num2 == "0") return "0";

        // Array to store the product of num1 and num2
        int[] result = new int[m + n];

        // Step 1: Multiply each digit of num1 and num2
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');  // Multiply the digits
                int p1 = i + j, p2 = i + j + 1;

                // Add the product to the appropriate position in the result array
                int sum = mul + result[p2];

                result[p2] = sum % 10;  // Store the remainder at the current position
                result[p1] += sum / 10;  // Carry over the quotient to the next position
            }
        }

        // Step 2: Convert the result array to a string, skipping leading zeros
        StringBuilder sb = new StringBuilder();
        foreach (int num in result) {
            if (!(sb.Length == 0 && num == 0)) {  // Skip leading zeros
                sb.Append(num);
            }
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
