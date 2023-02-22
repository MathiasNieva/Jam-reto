<template>
    <div>
      <check-box
        v-for="option in options"
        :checked="value.includes(option.artistaId)"
        @update:checked="check(option.artistaId, $event)"
        :fieldId="option.artistaId"
        :label="option.nombre"
        :key="option"
      />
    </div>
  </template>
  
  <script>
  import Checkbox from "./Checkbox.vue";
  
  export default {
    emits: ["update:value"],
    props: {
      value: {
        type: Array,
        required: true,
      },
      options: {
        type: Array,
        required: true,
      },
    },
    setup(props, context) {
      const check = (optionId, checked) => {
        let updatedValue = [...props.value];
        if (checked) {
          updatedValue.push(optionId);
        } else {
          updatedValue.splice(updatedValue.indexOf(optionId), 1);
        }
        context.emit("update:value", updatedValue);
      };
  
      return {
        check,
      };
    },
    components: {
      "check-box": Checkbox,
    },
  };
  </script>