// { Driver Code Starts
//Initial Template for javascript

"use strict";

process.stdin.resume();
process.stdin.setEncoding("utf-8");

let inputString = "";
let currentLine = 0;

process.stdin.on("data", (inputStdin) => {
  inputString += inputStdin;
});

process.stdin.on("end", (_) => {
  inputString = inputString
    .trim()
    .split("\n")
    .map((string) => {
      return string.trim();
    });

  main();
});

function readLine() {
  return inputString[currentLine++];
}

/* Function to print an array */
function printArray(arr, size) {
  let i;
  let s = "";
  for (i = 0; i < size; i++) {
    s += arr[i] + " ";
  }
  console.log(s);
}

function main() {
  let t = parseInt(readLine());
  let i = 0;
  for (; i < t; i++) {
    let inputAr = readLine().split(" ").map((x)=>parseInt(x));
    
    let n = inputAr[0];
    let m = inputAr[1];
    let k = inputAr[2];
    let A = new Array(n);
    let B = new Array(m);
    let input_ar1 = readLine().split(" ").map((x) => parseInt(x));
    for(let i = 0;i<n;i++)
      A[i] = input_ar1[i];
    let input_ar2 = readLine().split(" ").map((x) => parseInt(x));
    for(let i = 0;i<m;i++)
      B[i] = input_ar2[i];
  
    let obj = new Solution();
    let res = obj.kthElement(A,B,n,m,k);
    
    console.log(res);

  }
}// } Driver Code Ends


//User function Template for javascript

/**
 * @param {number[]} A
 * @param {number[]} B
 * @param {number} n
 * @param {number} m
 * @param {number} k
 * @returns {number}
 */

class Solution {
    kthElement(A,B,n,m,k){ 
        //code here
        var i = 0; var j = 0;
        var el = A[0];
        
        while(i < A.length && j < B.length){
            if(A[i] <= B[j]){
                el = A[i++];
            }else{
                el = B[j++];
            }
            k--;
            if(k == 0) {
                break;
            }
        }
        while(k > 0 && i < A.length){
            el = A[i++];
            k--;
        }
        while(k > 0 && j < B.length){
            el = B[j++];
            k--;
        }
        return el;
    }
}