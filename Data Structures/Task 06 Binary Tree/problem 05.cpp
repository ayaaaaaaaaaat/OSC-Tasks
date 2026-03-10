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
    int x = 0 ;
    int solve(TreeNode* root){
        if(!root) return 0;
        int s1 = solve(root->left);
        int s2 = solve(root->right);
        x = max(s1+s2,x);
        return max(s1,s2)+1;
    }
    int diameterOfBinaryTree(TreeNode* root) {
        solve(root);
        return x;
    }
};