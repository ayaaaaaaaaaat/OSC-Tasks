class Solution {
public:
    bool isPowerOfThree(int n) {
        // akbar power le el 3 by fit fe el int
        return n > 0 && (1162261467 % n == 0);
    }
};