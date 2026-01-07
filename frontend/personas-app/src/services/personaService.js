import axios from 'axios';

const API_URL = 'http://localhost:5217/api/Personas';

export const personaService = {
  getAll: async () => {
    const response = await axios.get(API_URL);
    return response.data;
  },

  searchByName: async (nombre) => {
    const response = await axios.get(`${API_URL}/buscar`, {
      params: { nombre }
    });
    return response.data;
  },

  create: async (persona) => {
    const response = await axios.post(API_URL, persona);
    return response.data;
  },

  delete: async (id) => {
    await axios.delete(`${API_URL}/${id}`);
    return true;
  }
};