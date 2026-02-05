class Solution {
public:
    int missingNumber(vector<int>& nums) {
        int sum = 0;
        for(int i=0;i<nums.size();++i) sum+=nums[i];
        return (nums.size()*(nums.size()+1))/2 - sum;
    }
};
class Solution {
public:
    int missingNumber(vector<int>& nums) {
        sort(nums.begin(),nums.end());
        int n = 0 ;
        for(auto i :nums){
            if(i != n) return n;
            ++n;
        }
        return n;
    }
};