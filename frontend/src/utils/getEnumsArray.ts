export const getEnumsArray = (enums) => {
  const values: number[] = []
  const labels: string[] = []
  for (const key in enums) {
    if (!Number.isNaN(Number(key))) {
      values.push(Number(key))
    } else {
      labels.push(key)
    }
  }

  return labels?.map((item, index) => ({ label: item, value: values[index] }))
}
