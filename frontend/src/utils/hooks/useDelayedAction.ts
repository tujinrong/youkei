import { onMounted, onUnmounted } from 'vue'
// todo: vueuse useIdle
/**動作停止後,遅延操作を行います */
const useDelayedAction = (callback: () => void, delay = 30000) => {
  let timer: NodeJS.Timeout | null = null

  const resetTimer = () => {
    if (timer) {
      clearTimeout(timer)
    }

    timer = setTimeout(() => {
      callback()
      resetTimer() // Recursive call, loop
    }, delay)
  }

  const handleAction = () => {
    resetTimer()
  }

  onMounted(() => {
    document.addEventListener('click', handleAction)
    document.addEventListener('keydown', handleAction)
    document.addEventListener('wheel', handleAction)
  })

  onUnmounted(() => {
    document.removeEventListener('click', handleAction)
    document.removeEventListener('keydown', handleAction)
    document.removeEventListener('wheel', handleAction)
    if (timer) {
      clearTimeout(timer)
    }
  })

  return {}
}

export default useDelayedAction
