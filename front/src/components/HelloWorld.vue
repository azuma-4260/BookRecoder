<template>
  <div class="container mx-auto p-4 bg-gray-50 min-h-screen">
    <h1 class="text-4xl font-bold text-center text-gray-800 mb-8">Hello API Response</h1>
    <div class="flex justify-center space-x-4 mb-8">
      <button @click="createData" class="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-6 rounded shadow">
        Create
      </button>
      <button @click="fetchData" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-6 rounded shadow">
        Read
      </button>
      <button @click="updateData" class="bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-2 px-6 rounded shadow">
        Update
      </button>
      <button @click="deleteData" class="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-6 rounded shadow">
        Delete
      </button>
    </div>
    <div v-if="response" class="mt-4 p-4 bg-gray-100 rounded shadow-lg">
      <pre class="text-gray-800">{{ response }}</pre>
    </div>
    <div class="container mx-auto p-4">
      <ul class="grid grid-cols-1 gap-8 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-3">
        <li v-for="book in books" :key="book.Id" class="bg-white shadow-lg rounded-lg p-6 transition-transform transform hover:scale-105">
          <h3 class="text-2xl font-semibold text-gray-800 mb-4">{{ book.Title }}</h3>
          <p class="text-gray-700 mb-2"><strong>Author:</strong> {{ book.Author }}</p>
          <p class="text-gray-700 mb-2"><strong>Genre:</strong> {{ book.Genre }}</p>
          <p class="text-gray-700"><strong>Thoughts:</strong> {{ book.Thoughts }}</p>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      response: null,
      books: [],
    };
  },
  methods: {
    async createData() {
      try {
        const res = await axios.post('http://localhost:5111/hello');
        this.response = res.data;
        console.log('Create Response:', this.response);
      } catch (error) {
        console.error('Error creating data:', error);
      }
    },
    async fetchData() {
      try {
        const res = await axios.get('http://localhost:5111/hello');
        console.log('Read Response:', res.data);
        this.books = res.data.map(bookData => this.createBook(bookData));
        this.response = null;
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    },
    async updateData() {
      try {
        const res = await axios.put('http://localhost:5111/hello');
        this.response = res.data;
        console.log('Update Response:', this.response);
      } catch (error) {
        console.error('Error updating data:', error);
      }
    },
    async deleteData() {
      try {
        const res = await axios.delete('http://localhost:5111/hello');
        this.response = res.data;
        console.log('Delete Response:', this.response);
      } catch (error) {
        console.error('Error deleting data:', error);
      }
    },
    createBook(bookData) {
      return {
        Id: bookData.Id,
        Title: bookData.Title,
        Author: bookData.Author,
        Genre: bookData.Genre,
        Thoughts: bookData.Thoughts
      };
    }
  },
};
</script>
