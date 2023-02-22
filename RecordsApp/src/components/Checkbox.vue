<template>
    <input
      @input="(event) => $emit('update:checked', event.target.checked)"
      type="checkbox"
      :checked="checked"
      :id="fieldId"
      class="mr-2 hidden"
    />
    <label
      :for="fieldId">
      {{ label }}
    </label>
  </template>
  
  <script>
  export default {
    props: {
      label: String,
      fieldId: {
        type: String,
      },
      checked: {
      type: Boolean,
    },
    },
  };
  </script>
  
<style scoped>
input {
    margin-left: 10px;
}


label {
    padding: 5px;
}
</style>