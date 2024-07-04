import { ref } from 'vue'

/**
 * @param initValue
 */
export default function useBoolean(initValue = false) {
  const bool = ref(initValue)

  function setBool(value: boolean) {
    bool.value = value
  }
  function setTrue() {
    setBool(true)
  }
  function setFalse() {
    setBool(false)
  }
  function toggle() {
    setBool(!bool.value)
  }

  function setFalseDelay() {
    setTimeout(() => {
      setBool(false)
    }, 200)
  }

  return {
    bool,
    setBool,
    setTrue,
    setFalse,
    setFalseDelay,
    toggle
  }
}
