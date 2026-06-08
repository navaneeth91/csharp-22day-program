<script setup>
import { ref, onMounted } from 'vue'

// Reactive array that will hold patients.

const cityInput = ref('');
const patients = ref([]);

const searchPatients = async () => {
  const res = await fetch(`https://localhost:7068/api/patients/search?searchcity=${cityInput.value}`);
  patients.value = await res.json();
};
</script>

<template>
  <h1 ><b>CareBridge Patients</b></h1>
  <form @submit.prevent="searchPatients">
    <input v-model="cityInput" type="text" placeholder="Please enter city" />
    <button type="submit">Search</button>
  </form>
  <h2>Showing the {{ patients.length }} records</h2>

  <table border="1">

    <tr>
      <th>Patient Id</th>
      <th>Full Name</th>
      <th>City</th>
      <th>IsActive</th>
    </tr>

    <!-- Loop through all patients -->

    <tr
      v-for="p in patients"
      :key="p.patientId">

      <td><b>{{ p.patientId }}</b></td>
      <td>{{ p.fullName }}</td>
      <td>{{ p.city }}</td>
      <td>{{ p.isActive }}</td>

    </tr>

  </table>

</template>
