class Solution {
public:
    int findTheWinner(int n, int k) {
        vector<bool> arr(n,1);
        int cnt = 0,last_removed=-1,i=k-1;
        while(1){
            i%=n;
            if(!arr[i]) {
                i++;
                continue;
            }
            last_removed = i;
            arr[i]=0;
            cnt++;
            if(cnt == n)break;
            int j = 0 ;i=(i+1)%n;
            while(j < k-1){
                if(arr[i]) j++;
                i=(i+1)%n;
            }
        }
        return last_removed+1;
    }
};