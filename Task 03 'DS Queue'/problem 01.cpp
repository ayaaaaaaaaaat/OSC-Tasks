class myQueue {
    int capacity;
    int begin;
    int end;
    int size;
    int* q;

  public:
    myQueue(int n) {
        // Define Data Structures
        size = 0 ;
        capacity = n ;
        begin = end = -1;
        q = new int[capacity];
    }

    bool isEmpty() {
        // check if the queue is empty
        return !size ;
    }

    bool isFull() {
        // check if the queue is full
        return size == capacity;
    }

    void enqueue(int x) {
        // Adds an element x at the rear of the queue.
        if (isFull()) expand();
        if (isEmpty()) begin = end = 0;
        else end = (end + 1) % capacity;
        q[end] = x;
        size++;
    }

    void dequeue() {
        // Removes the front element of the queue.
        if(isEmpty()) return;
        begin = (begin + 1) % capacity;
        size--;
        if (!size) begin = end = -1;
    }

    int getFront() {
        // Returns the front element of the queue.
        if(isEmpty()) return -1;
        return q[begin];
    }

    int getRear() {
        // Return the last element of queue
        if(isEmpty()) return -1;
        return q[end];
    }
    void expand() {
		int* q2 = new int[2 * capacity];
		//for (int a = begin; a <= end; (a++)%size) q2[a] = q[a];
		for (int i = 0; i < capacity; i++) {
			q2[i] = q[(begin + i) % capacity];
		}
		delete[] q;
		q = q2;
		begin = 0;
		end = size - 1;
		capacity *= 2;
		q2 = nullptr;
	}
};