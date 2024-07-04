import { areaOptions, officeOptions, oneResultOptions, residentOptions } from './content'

export const getDetailSearchData = (data: any): Promise<unknown> => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve({
        data: {
          areaOptions,
          officeOptions,
          oneResultOptions,
          residentOptions
        }
      })
    }, 1000)
  })
}
