/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    bool flg = 1;
    int solve(TreeNode* root){
        if(root == nullptr) return 0;
        int a1 = solve(root->left);
        int a2 = solve(root->right);
        if(abs(a1-a2)>1)flg=0;
        return max(a1,a2)+1;
    }
    bool isBalanced(TreeNode* root) {
        solve(root);
        return flg;
    }
};