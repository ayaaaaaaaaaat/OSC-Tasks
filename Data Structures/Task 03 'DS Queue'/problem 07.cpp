class DataStream {
public:
    int v,k,cnt=0;
    DataStream(int value, int k) {
      v = value;
      this->k = k; 
    }
    
    bool consec(int num) {
        if(num != v) cnt = 0;
        else cnt++;
        return cnt >= k;
    }
};

/**
 * Your DataStream object will be instantiated and called as such:
 * DataStream* obj = new DataStream(value, k);
 * bool param_1 = obj->consec(num);
 */