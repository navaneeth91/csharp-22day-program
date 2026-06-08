<script setup>
import { ref, onMounted } from 'vue'

// Reactive array that will hold patients.
const patients = ref([])

// Runs automatically when page loads.
onMounted(async () => {

  // Call ASP.NET Core API. – Change the port
  const response =
    await fetch('https://localhost:7068/api/analytics/department-load')

  // Convert JSON into JavaScript objects.
  patients.value =
    await response.json()

})
</script>

<template>

  <h1>Department Load</h1>

  <table border="1">

    <tr>
      <th>Department</th>
      <th>inpatientCount</th>
      <th>outpatientCount</th>
      <th>ed</th>
      <th>total</th>
    </tr>

    <!-- Loop through all patients -->

    <tr
      v-for="p in patients"
      :key="p.patientId">

      <td>{{ p.department }}</td>
      <td>{{ p.inpatientCount }}</td>
      <td>{{ p.outpatientCount }}</td>
      <td>{{ p.edCount }}</td>
      <td>{{ p.total }}</td>

    </tr>

  </table>

</template>
