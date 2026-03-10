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
    int lefth(TreeNode* root){
        if(!root) return 0;
        return lefth(root->left) + 1 ;
    }
    int righth(TreeNode* root){
        int x = 0;
        while(root){
            ++x;
            root=root->right;
        }
        return x;
    } 
    int countNodes(TreeNode* root) {
        int lh = lefth(root);
        int rh = righth(root);

        if(lh == rh) return pow(2,lh) - 1;
        return countNodes(root->left) + countNodes(root->right) + 1;
    }
};