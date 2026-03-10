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
    deque<TreeNode*> tmp;
    vector<vector<int>> ans;
    bool rtol = 0;
    vector<vector<int>> zigzagLevelOrder(TreeNode* root) {
        if (!root) return ans;
        tmp.push_back(root);
        while(tmp.size()){
            int n = tmp.size();
            vector<int> v;
            for (int i = 0; i < n; ++i) {
                TreeNode* curr ;
                if(rtol){
                    curr = tmp.back();
                    tmp.pop_back();
                    if(curr->right != nullptr)tmp.push_front(curr->right);
                    if(curr->left != nullptr)tmp.push_front(curr->left);
                }
                else{
                    curr = tmp.front();
                    tmp.pop_front();
                    if(curr->left != nullptr)tmp.push_back(curr->left);
                    if(curr->right != nullptr)tmp.push_back(curr->right);
                }
                v.push_back(curr->val);
            }
            rtol= !rtol;
            ans.push_back(v);
        }
        return ans;
    }
};