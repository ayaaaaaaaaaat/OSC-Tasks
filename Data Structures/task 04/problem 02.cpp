class Solution {
  public:
    int getSecondLargest(vector<int> &arr) {
        // code here
        int mx = -1 , last = -1;
        sort(arr.begin(),arr.end());
        for(auto i : arr){
            if(i > mx){
                last = mx;
                mx = i;
            }
        }
        return last;
        
    }
};